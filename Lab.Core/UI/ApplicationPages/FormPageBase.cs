﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using Lab.Core.Di;
using Lab.Core.DomainObjects;
using Lab.Core.Services;
using Microsoft.SharePoint.WebControls;
using Ninject;

namespace Lab.Core.UI.ApplicationPages
{
    public class FormPageBase<TObject> : LayoutsPageBase where TObject : IObjectBase
    {
        public FormPageBase()
        {
            DiHelper.Kernel.Inject(this);
        }

        private readonly HtmlInputText jsonBridge = new HtmlInputText("hidden");

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Add(jsonBridge);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            LoadObject();
        }

        /// <summary>
        ///     This service should be used to manage objects corresponding to TObject.
        /// </summary>
        [Inject]
        public IObjectAdministrationService<TObject> Service { get; set; }

        /// <summary>
        ///     This methods uses parameter from query string to load an item.
        ///     This item will be serialized to JSON.
        ///     The JSON string should be transported in the bridge.
        /// </summary>
        protected void LoadObject()
        {
            if (!IsPostBack)
            {
                const string idParameter = "id";
                var parameters = HttpUtility.ParseQueryString(ClientQueryString);
                if (!String.IsNullOrEmpty(parameters[idParameter]))
                {
                    var id = parameters[idParameter];
                    var currentObject = Service.GetBy(id);
                    jsonBridge.Value = currentObject.Json.AsString();
                }
            }
        }

        protected void Handle(string messageKey)
        {
            // TODO implement this method
            var exception = new Exception( /* res get value for messageKey */);
            Handle(exception);
        }

        protected void Handle(Exception exception)
        {
            // TODO implement this method
            // log error
            // redirect to hint page and show message
        }
    }
}