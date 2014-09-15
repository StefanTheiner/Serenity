﻿
namespace BasicApplication.Administration
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("UserId"), NameProperty("Username"), IsActiveProperty("IsActive")]
    [FormKey("Administration.User"), LocalTextPrefix("Administration.User"), Service("Administration/User")]
    public class UserDialog : EntityDialog<UserRow>
    {
        private UserForm form;

        public UserDialog()
        {
            form = new UserForm(this.IdPrefix);

            form.Password.AddValidationRule(this.uniqueName, e =>
            {
                if (form.Password.Value.Length < 7)
                    return "Password must be at least 7 characters!";

                return null;
            });

            form.PasswordConfirm.AddValidationRule(this.uniqueName, e =>
            {
                if (form.Password.Value != form.PasswordConfirm.Value)
                    return "The passwords entered doesn't match!";

                return null;
            });
        }
    }
}