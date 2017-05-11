using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oaworkers
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {
        BLL.Workers bll = new BLL.Workers();
        Model.Workers model = new Model.Workers();
        public string checkAccount = "/Tools/CheckAccount.ashx";
        public string account;

        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(10001, ddlType, true);

                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                    checkAccount = "";
                }
            }
        }


        /// <summary>
        /// 绑定人员详细
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            model = bll.GetModel(id);
            txtEmail.Text = model.Email;
            txtNameInfo.Text = model.NameInfo;
            txtPhone.Text = model.Phone;
            ddlType.SelectedValue = model.TypeId.ToString();
            ckState.Checked = model.StateInfo == 1 ? true : false;
            account = model.Account;
            txtPwd.Text = Common.DESEncrypt.Decrypt(model.Pwd);
           


        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            bool isEdit = false;

            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                isEdit = true;
            }
            else
            {
                model.NumId = bll.SetNumID();
                model.AddTime = DateTime.Now;
                model.Pwd = Leadin.Common.DESEncrypt.Encrypt(txtPwd.Text.Trim());
            }


            model.Account = Request.Form["txtAccount"].ToString();
            model.Email = txtEmail.Text;
            model.NameInfo = txtNameInfo.Text;
            model.Phone = txtPhone.Text;
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.TypeId = int.Parse(ddlType.SelectedValue);


            if (isEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("人员信息修改成功", 2000, "true", "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("人员信息修改失败，请稍候重试", 2000, "false");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("人员信息录入成功", 2000, "true", "index.aspx");
                }
                else
                {
                    JsMessage("人员信息录入失败，请稍候重试", 2000, "false");
                }
            }


        }
    }
}