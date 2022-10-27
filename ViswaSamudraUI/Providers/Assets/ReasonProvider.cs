﻿using System;
using System.Collections.Generic;
using io = VSAssetManagement.IOModels;

namespace ViswaSamudraUI.Providers.Assets
{
    public class ReasonProvider
    {
        CommonHelper ch = new CommonHelper();
        public IEnumerable<io.Reason> GetAllReason(io.Reason PoIoModel = null)
        {
            if (PoIoModel == null)
                return (IEnumerable<io.Reason>)ch.GetRequest<io.Reason>("reason");
            else
                return (IEnumerable<io.Reason>)ch.GetDetailsRequest<io.Reason>("reason/reasonsearch", PoIoModel);
        }
        public string AddReason(io.Reason PoIoModel = null)
        {
            if (PoIoModel != null)
            {
                if (PoIoModel.Guid == Guid.Empty)
                {
                    return ch.PostRequest<io.Reason>("reason/CreateResult", PoIoModel);
                }
                return ch.PostRequest<io.Reason>("reason/UpdateResult", PoIoModel);
            }
            else
                return null;
        }
    }
}