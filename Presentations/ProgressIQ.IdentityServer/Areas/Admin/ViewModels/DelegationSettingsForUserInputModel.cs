﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using IdentityServer.Models;
using IdentityServer.Repositories;
using ProgressIQ.IdentityServer.Web.Areas.Admin.Resources;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class DelegationSettingsForUserViewModel
    {
        private IDelegationRepository delegationRepository;
        IUserManagementRepository userManagementRepository;
        
        [Required]
        public string UserName { get; set; }
        public IEnumerable<DelegationSetting> DelegationSettings { get; set; }

        public bool IsNew
        {
            get
            {
                return this.UserName == null;
            }
        }

        public IEnumerable<SelectListItem> AllUserNames { get; set; }

        public DelegationSettingsForUserViewModel(IDelegationRepository delegationRepository, IUserManagementRepository userManagementRepository, string username)
        {
            this.delegationRepository = delegationRepository;
            this.userManagementRepository = userManagementRepository;
            int totalCount;
            var allnames =
                userManagementRepository.GetUsers(0, 100, out totalCount)
                .Select(x => new SelectListItem
                {
                    Text = x
                }).ToList();
            allnames.Insert(0, new SelectListItem { Text = DelegationSettingsForUserInputModel.ChooseItem, Value = "" });
            this.AllUserNames = allnames;
            
            this.UserName = username;
            if (!IsNew)
            {
                var realmSettings =
                        this.delegationRepository
                            .GetDelegationSettingsForUser(this.UserName)
                            .ToArray();
                this.DelegationSettings = realmSettings;
            }
            else
            {
                this.DelegationSettings = new DelegationSetting[0];
            }
        }
    }
}