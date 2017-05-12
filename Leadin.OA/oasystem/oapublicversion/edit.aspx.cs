using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oapublicversion
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {
        BLL.PublicVersion bll = new BLL.PublicVersion();
        Model.PublicVersion model = new Model.PublicVersion();

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }


        /// <summary>
        /// 绑定公版详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            model = bll.GetModel(id);

            txtNameInfo.Text = model.NameInfo;
            txtNum.Text = model.Num.ToString();
            txtRemark.Text = model.Remark;
            txtSortNum.Text = model.SortNum.ToString();
            ckState.Checked = model.StateInfo == 1 ? true : false;
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
                model = bll.GetModel(id);
                isEdit = true;
            }
            else {
                model.NumId = bll.SetNumID();
            }

            model.ImgUrl = "";
            model.NameInfo = txtNameInfo.Text;
            model.Num = int.Parse(txtNum.Text);
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;

            if (isEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("公版信息修改成功", 2000, "true", "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("公版信息修改失败，请稍候重试", 2000, "false");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("公版信息录入成功", 2000, "true", "index.aspx");
                }
                else
                {
                    JsMessage("公版信息录入失败，请稍候重试", 2000, "false");
                }
            }

        }
    }
}