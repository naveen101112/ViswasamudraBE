﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using ViswaSamudraUI.Providers.Assets;
using VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Controllers.WINGS
{
    public class AssetRequisitionController : Controller
    {
        //AssetProvider provider = new AssetProvider();
        List<AssetRequisitionDetails> arDetails = new List<AssetRequisitionDetails>();
        AssetRequisitionHeader aHeader = new AssetRequisitionHeader();
        AssetRequisition aRequisition = new AssetRequisition();
        LookUpProvider lookUpProvider = new LookUpProvider();
        ProjectProvider projectProvider = new ProjectProvider();
        AssetRequistionProvider assetRequistionProvider = new AssetRequistionProvider();

        public IActionResult Index()
        {
            aHeader.RecordStatus = 1;
            aRequisition.header = aHeader;
            IEnumerable<AssetRequisition> list = assetRequistionProvider.GetAll(aRequisition).OrderByDescending(a=>a.header.Id);
            return View(list);
        }

        public ActionResult AssetRequisitionModification(AssetRequisition model)
        {
            return Ok(assetRequistionProvider.Add(model));
        }
        public async Task<IActionResult> AssetRequisitionOps(AssetRequisitionHeader model)
        {
            aHeader.Guid = model.Guid;
            aRequisition.header = aHeader;
            AssetRequisition AssetReq = aRequisition;

            if (model.Guid == System.Guid.Empty)
            {
                ViewBag.RequestedUsers = lookUpProvider.GetTempUserData();
                ViewBag.ApproveUsers = lookUpProvider.GetTempUserData();
                ViewBag.TaskType = lookUpProvider.GetSelectList("TTY");
                ViewBag.Project = projectProvider.GetSelectList();
            }
            else
            {
                
                AssetReq = assetRequistionProvider.GetAll(aRequisition).FirstOrDefault();
                ViewBag.RequestedUsers = lookUpProvider.GetTempUserData(AssetReq.header.RequestedBy);
                ViewBag.ApproveUsers = lookUpProvider.GetTempUserData(AssetReq.header.ApprovedBy);
                ViewBag.TaskType = lookUpProvider.GetSelectList("TTY", AssetReq.header.TaskType.ToString());
                ViewBag.Project = projectProvider.GetSelectList(AssetReq.header.Project.ToString());
            }           
            
            ViewBag.StructureType = lookUpProvider.GetSelectList("STY");
            ViewBag.StructureSubType = lookUpProvider.GetSelectList("SST");
            ViewBag.AssetType = lookUpProvider.GetSelectList("ATY");
            ViewBag.AssetSpecification = lookUpProvider.GetSelectList("ATS");
            ViewBag.Uom = lookUpProvider.GetSelectList("UOM");

            return View(AssetReq);
        }
        public IActionResult Delete(AssetRequisition model)
        {
            //ResponseBody res = provider.Delete(model);
            //if (res != null && res.Status == true)
            //{
            //    IEnumerable<Project> list = provider.GetAll();
            //    return View("Index", list);
            //}
            //else
            //{
            //    return Ok(res);
            //}
            return null;
        }
    }
}
