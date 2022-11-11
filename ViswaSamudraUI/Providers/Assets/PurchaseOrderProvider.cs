using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ViswaSamudraUI.Models;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
    public class PurchaseOrderProvider
    {
        CommonHelper ch = new CommonHelper();
        public List<io.PurchaseOrder> GetAllPurchaseOrder(io.PurchaseOrder PoIoModel = null)
        {
            if (PoIoModel == null)
                return (List<io.PurchaseOrder>)ch.GetRequest<io.PurchaseOrder>("purchaseOrder");
            else
                return (List<io.PurchaseOrder>)ch.GetDetailsRequest<io.PurchaseOrder>("purchaseOrder/posearch", PoIoModel);
        }
        public ResponseBody AddPurchaseOrder(io.PurchaseOrder PoIoModel = null)
        {
            if (PoIoModel != null)
            {
                if (PoIoModel.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.PurchaseOrder>("purchaseOrder/CreatePO", PoIoModel);
                }
                return ch.PostRequest<io.PurchaseOrder>("purchaseOrder/UpdatePo", PoIoModel);
            }
            else
                return null;
        }

        public IEnumerable<io.PurchaseOrder> GetDropDown()
        {
            return (IEnumerable<io.PurchaseOrder>)ch.GetRequest<io.PurchaseOrder>("purchaseOrder/combo");
        }

        public List<SelectListItem> GetSelectList(string SelectedValue = null)
        {
            SelectListItem selListItem = new SelectListItem() { Value = "", Text = "" };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);

            foreach (var x in GetDropDown().Select(i => new { i.Id, i.PurchaseOrderNo, i.Guid }))
            {
                if (SelectedValue != null && x.Guid.ToString() == SelectedValue)
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.PurchaseOrderNo, Selected = true };
                else
                    selListItem = new SelectListItem() { Value = x.Guid.ToString(), Text = x.PurchaseOrderNo };

                newList.Add(selListItem);
            }
            return newList;
        }
    }
}