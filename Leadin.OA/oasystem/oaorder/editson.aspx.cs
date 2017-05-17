using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oaorder
{
    public partial class editson : Leadin.Web.UI.ManagePage
    {
        BLL.Customer bllCustomer = new BLL.Customer();
        BLL.Paper bllPaper = new BLL.Paper();
        BLL.PublicVersion bllPublicversion = new BLL.PublicVersion();
        BLL.Technology bllTechnology = new BLL.Technology();
        BLL.SonOrder bllSonOrder = new BLL.SonOrder();
        BLL.OrdeTechnology bllOrderTechnology = new BLL.OrdeTechnology();
        BLL.FatherOrder bllFathrt = new BLL.FatherOrder();

        int fid;
        int sid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["fid"], out fid))
                {
                    BindCustomer(fid);
                    BindPaper();
                    BindddlType(10014, ddlType, true);
                    BindTechnology();

                    if (int.TryParse(Request.Params["sid"], out sid))
                    {
                        BindDetail(sid);
                    }

                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }


        void BindDetail(int sonid)
        {
            Model.SonOrder model = bllSonOrder.GetModel(sonid);

            DataSet ds = bllPublicversion.GetList("StateInfo=1 and Num>0 and CustomerId=" + model.CustomerID);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ddlPublicversion.Items.Add(new ListItem(item["NameInfo"].ToString(), item["Id"].ToString()));
            }

            txtDifferencePrice.Text = model.DifferencePrice.ToString("0.00");
            txtDifferenceReason.Text = model.DifferenceReason;
            txtExplain.Text = model.Explain;
            txtFileName.Text = model.Remark;
            txtNum.Text = model.Num.ToString("0.0");
            ddlCustomer.SelectedValue = model.CustomerID.ToString();
            ddlPaper.SelectedValue = model.PaperId.ToString();
            ddlPublicversion.SelectedValue = model.PublicVersionId.ToString();
            ddlType.SelectedValue = model.TypeId.ToString();


            for (int i = 0; i < repTechnology.Items.Count; i++)
            {
                Repeater repSubTechnology = repTechnology.Items[i].FindControl("repSubTechnology") as Repeater;

                for (int j = 0; j < repSubTechnology.Items.Count; j++)
                {
                    HiddenField hidsubId = repSubTechnology.Items[j].FindControl("hidsubId") as HiddenField;

                    if (bllOrderTechnology.GetRecordCount("TechnologyId="+hidsubId.Value+ " and SonOrderId="+sonid) > 0)
                    {
                        CheckBox ckTechnology = repSubTechnology.Items[j].FindControl("ckTechnology") as CheckBox;

                        ckTechnology.Checked = true;

                    }

                }
            }


        }



        /// <summary>
        /// 绑定客户下拉列表
        /// </summary>
        void BindCustomer(int fid)
        {

            Model.FatherOrder model = bllFathrt.GetModel(fid);

            Model.Customer modelcustomer = bllCustomer.GetModel(int.Parse(model.CustomerId.ToString()));

            DataSet ds = bllCustomer.GetList(0, "ParentId=" + modelcustomer.Id + " and StateInfo=1", "AddTime asc,Id asc");
            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    ddlCustomer.Items.Add(new ListItem(item["CompanyName"].ToString(), item["Id"].ToString()));
                }
            }
            else
            {
                ddlCustomer.Items.Add(new ListItem(modelcustomer.CompanyName, modelcustomer.Id.ToString()));
            }
        }



        /// <summary>
        /// 绑定纸张
        /// </summary>
        void BindPaper()
        {
            DataSet ds = bllPaper.GetList(0, "StateInfo=1", "SortNum desc,Id asc");

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ddlPaper.Items.Add(new ListItem(item["NameInfo"].ToString() + "(" + item["PaperSpec"].ToString() + ")", item["Id"].ToString()));
            }

        }


        /// <summary>
        /// 绑定工艺
        /// </summary>
        void BindTechnology()
        {

            DataSet ds = bllTechnology.GetList(0, "StateInfo=1 and ParentId=0", "SortNum desc,Id asc");

            repTechnology.DataSource = ds;
            repTechnology.DataBind();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                HiddenField hidId = repTechnology.Items[i].FindControl("hidId") as HiddenField;
                Repeater repSubTechnology = repTechnology.Items[i].FindControl("repSubTechnology") as Repeater;
                repSubTechnology.DataSource = bllTechnology.GetList(0, "StateInfo=1 and ParentId=" + ds.Tables[0].Rows[i]["Id"].ToString(), "SortNum desc,Id asc");
                repSubTechnology.DataBind();
            }
        }



        protected void btnOK_Click(object sender, EventArgs e)
        {
            int fathrtId = int.Parse(Request.Params["fid"]);
            bool isEdit = false;
            Model.SonOrder model = new Model.SonOrder();

            if (int.TryParse(Request.Params["sid"], out sid))
            {
                isEdit = true;
                model = bllSonOrder.GetModel(sid);
                
            }
            else
            {
                model.NumId = SetSonNumID(fathrtId);
            }
            model.AddTime = DateTime.Now;
            model.DifferencePrice = decimal.Parse(txtDifferencePrice.Text);
            model.DifferenceReason = txtDifferenceReason.Text;
            model.Explain = txtExplain.Text;
            model.FatherOrderId = fathrtId;
            model.Num = decimal.Parse(txtNum.Text);
            model.PaperId = int.Parse(ddlPaper.SelectedValue);
            model.CustomerID = int.Parse(ddlCustomer.SelectedValue);
            if (!string.IsNullOrEmpty(Request.Form["ddlPublicversion"]))
            {
                model.PublicVersionId = int.Parse(Request.Form["ddlPublicversion"]);
            }
            model.StateInfo = 10022;
            model.TypeId = int.Parse(ddlType.SelectedValue);
            model.WorkersId = int.Parse(Session["AdminId"].ToString());
            model.Remark = txtFileName.Text;

            if (isEdit)
            {
                if (bllSonOrder.Update(model))
                {
                    


                    DataSet ds = bllOrderTechnology.GetList("SonOrderId="+sid);

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        bllOrderTechnology.Delete(int.Parse(item["Id"].ToString()));
                    }

                    AddTechnology(sid);

                    JsMessage("客户订单信息修改成功", 2000, "true", "sonindex.aspx" + Request.Url.Query);

                }
                else
                {
                    JsMessage("客户订单信息修改失败", 2000, "false");
                }
            }
            else
            {
                sid = bllSonOrder.Add(model);

                if ( sid > 0)
                {
                    AddTechnology(sid);

                    JsMessage("客户订单信息添加成功", 2000, "true", "sonindex.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("客户订单信息添加失败", 2000, "false");
                }
            }
        }


        /// <summary>
        /// 添加订单工艺
        /// </summary>
        /// <param name="sonId"></param>
        void AddTechnology(int sonId)
        {
            Model.OrdeTechnology model = new Model.OrdeTechnology();

            for (int i = 0; i < repTechnology.Items.Count; i++)
            {
                Repeater repSubTechnology = repTechnology.Items[i].FindControl("repSubTechnology") as Repeater;

                for (int j = 0; j < repSubTechnology.Items.Count; j++)
                {
                    CheckBox ckTechnology = repSubTechnology.Items[j].FindControl("ckTechnology") as CheckBox;

                    if (ckTechnology.Checked)
                    {
                        HiddenField hidsubId = repSubTechnology.Items[j].FindControl("hidsubId") as HiddenField;
                        HiddenField hidPrice = repSubTechnology.Items[j].FindControl("hidPrice") as HiddenField;
                        model.Price = decimal.Parse(hidPrice.Value);
                        model.SonOrderId = sonId;
                        model.TechnologyId = int.Parse(hidsubId.Value);
                        bllOrderTechnology.Add(model);
                    }
                }
            }
        }





        /// <summary>
        /// 获取客户订单编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SetSonNumID(int fathrtId)
        {
            Model.FatherOrder model = bllFathrt.GetModel(fathrtId);

            StringBuilder strNumId = new StringBuilder();
            strNumId.Append(model.NumId);
            strNumId.Append("-");
            DataSet ds = bllSonOrder.GetList(0, "FatherOrderId=" + fathrtId, "NumId desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                strNumId.Append(int.Parse(ds.Tables[0].Rows[0]["NumId"].ToString().Split('-')[1]).ToString().PadLeft(3, '0'));
            }
            else
            {
                strNumId.Append("001");
            }
            return strNumId.ToString();

        }



    }
}