using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Leadin.OA.oasystem.oacustomer
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {
        BLL.Customer bll = new BLL.Customer();
        Model.Customer model = new Model.Customer();

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindParentCompany();
                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }



        /// <summary>
        /// 绑定直接客户
        /// </summary>
        void BindParentCompany()
        {
            DataSet ds = bll.GetList(0, "ParentId=0 and StateInfo=1", "AddTime asc");

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ListItem list = new ListItem();
                list.Text = item["CompanyName"].ToString();
                list.Value = item["Id"].ToString();

                ddlParentID.Items.Add(list);

            }
        }



        /// <summary>
        /// 绑定供应商详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            model = bll.GetModel(id);

            txtCompanyName.Text = model.CompanyName;
            txtAddress.Text = model.Addressinfo;
            txtEmail.Text = model.Email;
            txtExplain.Text = model.Explain;
            txtNameInfo.Text = model.NameInfo;
            txtPhone.Text = model.Phone;
            txtQQ.Text = model.QQNum;
            txtWechat.Text = model.WeChat;

            ddlParentID.SelectedValue = model.ParentId.ToString();
          


        }


        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }

            model.Addressinfo = txtAddress.Text;
            model.CompanyName = txtCompanyName.Text;
            model.Email = txtEmail.Text;
            model.Explain = txtExplain.Text;
            model.NameInfo = txtNameInfo.Text;
            model.Phone = txtPhone.Text;
            model.QQNum = txtQQ.Text;
            model.ParentId=int.Parse(ddlParentID.SelectedValue);
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.Tel = "";
           
            model.WeChat = txtWechat.Text;
            model.SourceId = 10013;
            if (isEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("供应商信息修改成功", 2000, "true", "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("供应商信息修改失败，请稍候重试", 2000, "false");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("供应商录入成功", 2000, "true", "index.aspx");
                }
                else
                {
                    JsMessage("供应商信息录入失败，请稍候重试", 2000, "false");
                }
            }

        }
    }
}