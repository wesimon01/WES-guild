using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarDealership.Models;
using CarDealership.BLL;

namespace CarDealership.UI.ViewModels
{
    public class InforequestupdateVM
    {
        
        public List<SelectListItem> _Requestitems = new List<SelectListItem>();
        public int _selectedRequestId { get; set; }
        public List<InfoRequest> _requests { get; set; }
        public RequestStatus _status { get; set; }

        public void SetRequestItems(List<InfoRequest> requests)
        {
            foreach (var request in requests)
            {
                _Requestitems.Add(new SelectListItem()
                {
                    Value = request.InfoRequestId.ToString(),
                    Text = request.PersonName + " " + request.InfoRequestId
                });
            }
        }


    }
}