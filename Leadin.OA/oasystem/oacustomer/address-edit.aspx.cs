using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oacustomer
{
    public partial class address_edit : Leadin.Web.UI.ManagePage
    {

        BLL.CustomerAddress bllAddress = new BLL.CustomerAddress();
        Model.CustomerAddress modelAddress = new Model.CustomerAddress();


        int cid;
        int id;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["cid"], out cid))
                {
                    if (int.TryParse(Request.Params["id"], out id))
                    {
                        BindDetail(id);
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }


        /// <summary>
        /// 绑定收获地址详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            modelAddress = bllAddress.GetModel(id);
            txtAddress.Text = modelAddress.Addressinfo;
            txtNameInfo.Text = modelAddress.NameInfo;
            txtPhone.Text = modelAddress.Phone;
            ckState.Checked = modelAddress.StateInfo == 1 ? true : false;
        }



        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            bool isEdit = false;

            if (int.TryParse(Request.Params["id"], out id))
            {
                modelAddress = bllAddress.GetModel(id);
                isEdit = true;
            }

            modelAddress.Addressinfo = txtAddress.Text;
            modelAddress.CustimerId = int.Parse(Request.Params["cid"]);
            modelAddress.NameInfo = txtNameInfo.Text;
            modelAddress.Phone = txtPhone.Text;

            if (isEdit)
            {
                if (bllAddress.Update(modelAddress))
                {
                    JsMessage("收货地址信息修改成功", 2000, "true", "address-index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("收货地址信息修改失败，请稍候重试", 2000, "false");
                }
            }
            else
            {
                if (bllAddress.Add(modelAddress) > 0)
                {
                    JsMessage("收货地址录入成功", 2000, "true", "address-index.aspx");
                }
                else
                {
                    JsMessage("收货地址信息录入失败，请稍候重试", 2000, "false");
                }
            }

        }
    }
}