using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;
using Database;
using System.Collections.Generic;
using Web.ACM;

namespace NewHRM
{
    public partial class CorporationProduct : System.Web.UI.Page
    {
        #region Step1
        int count = 0;
        int take = 0;
        int Skip = 0;
        public static int ChoiceID = 0;
        #endregion
        CallEntities DB = new CallEntities();
        CallEntities DB1 = new CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Readonly();
                ManageLang();
                pnlSuccessMsg.Visible = false;
                FillContractorID();
                int CurrentID = 1;
                if (ViewState["Es"] != null)
                    CurrentID = Convert.ToInt32(ViewState["Es"]);
                BindData();
                LastData();

            }
        }
        #region Step2
        public void BindData()
        {
            //List<CorporationProduct> List = DB1.CorporationProducts.OrderBy(m => m.CategoryID).ToList();
            var List = DB1.CorporationProducts.Where(P => P.Activated == true).OrderByDescending(p => p.ID).ToList();
            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = List.Count();
            ((ACMMaster)Page.Master).Loadlist(Showdata, take, Skip, ChoiceID, lblShowinfEntry, btnPrevious1, btnNext1, Listview1, ListView2, Totalrec, List);
        }
        #endregion

        public void GetShow()
        {

            lblProductName1s.Attributes["class"] = lblCategoryID1s.Attributes["class"] = "control-label col-md-4  getshow";
            lblProductName2h.Attributes["class"] = lblCategoryID2h.Attributes["class"] = "control-label col-md-4  gethide";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "ltr");

        }

        public void GetHide()
        {
            lblProductName1s.Attributes["class"] = lblCategoryID1s.Attributes["class"] = "control-label col-md-4  gethide";
            lblProductName2h.Attributes["class"] = lblCategoryID2h.Attributes["class"] = "control-label col-md-4  getshow";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "rtl");

        }
        protected void btnHide_Click(object sender, EventArgs e)
        {
            GetHide();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetShow();
        }

        public void Clear()
        {
            txtProductName.Text = "";
            drpCategoryID.SelectedIndex = 0;
           
           

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (btnAdd.Text == "AddNew")
                    {

                        Write();
                        Clear();
                        btnAdd.Text = "Add";
                        btnAdd.ValidationGroup = "s";
                    }
                    else if (btnAdd.Text == "Add")
                    {
                        btnAdd.ValidationGroup = "s";
                        Database.CorporationProduct objCorporationProduct = new Database.CorporationProduct();
                        //Server Content Send data Yogesh
                        objCorporationProduct.ProductName = txtProductName.Text;
                        objCorporationProduct.CategoryID = Convert.ToInt32(drpCategoryID.SelectedValue);
                        objCorporationProduct.Activated = true;
                        objCorporationProduct.Deleted = true;
                        objCorporationProduct.DateTime = DateTime.Now;


                        DB1.CorporationProducts.AddObject(objCorporationProduct);
                        DB1.SaveChanges();
                        Clear();
                        lblMsg.Text = "  Data Save Successfully";
                        pnlSuccessMsg.Visible = true;
                        BindData();
                        btnAdd.Text = "AddNew";
                        //navigation.Visible = true;
                        Readonly();
                        LastData();
                    }
                    else if (btnAdd.Text == "Update")
                    {

                        if (ViewState["Edit"] != null)
                        {
                            
                            int TsID = Convert.ToInt32(ViewState["Edit"]);
                            Database.CorporationProduct objCorporationProduct = DB1.CorporationProducts.Single(p => p.ID == TsID);
                            objCorporationProduct.ProductName = txtProductName.Text;
                            objCorporationProduct.CategoryID = Convert.ToInt32(drpCategoryID.SelectedValue);

                            ViewState["Edit"] = null;
                            btnAdd.ValidationGroup = "submit";
                            
                            DB1.SaveChanges();
                            Clear();
                            lblMsg.Text = "  Data Edit Successfully";
                            pnlSuccessMsg.Visible = true;
                            BindData();
                            btnAdd.Text = "AddNew";
                            //navigation.Visible = true;
                            Readonly();
                            LastData();
                        }
                    }
                    BindData();

                    scope.Complete(); //  To commit.

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect(Session["Previous"].ToString());
            Response.Redirect("CorporationProduct.aspx");
            btnAdd.Text = "AddNew";
        }
        public void FillContractorID()
        {
            //drpCreatedBy.Items.Insert(0, new ListItem("-- Select --", "0"));drpCreatedBy.DataSource = DB.0;drpCreatedBy.DataTextField = "0";drpCreatedBy.DataValueField = "0";drpCreatedBy.DataBind();
        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            FirstData();
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            NextData();
        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            PrevData();
        }
        protected void btnLast_Click(object sender, EventArgs e)
        {
            LastData();
        }
        int LIDID;
        public void FirstData()
        {
            LIDID = DB1.CorporationProducts.Where(p => p.Activated == true).FirstOrDefault().ID;
            Listview1.SelectedIndex = LIDID;
            BindCommand(LIDID);
            Readonly();

        }
        public void NextData()
        {

            Listview1.SelectedIndex = Listview1.SelectedIndex + 1;
            LIDID = Convert.ToInt32(Listview1.SelectedIndex);
            Listview1.SelectedIndex = LIDID;
            BindCommand(LIDID);
            Readonly();

        }
        public void PrevData()
        {
            Listview1.SelectedIndex = Listview1.SelectedIndex - 1;
            LIDID = Convert.ToInt32(Listview1.SelectedIndex);
            LIDID = Listview1.SelectedIndex;
            BindCommand(LIDID);
            Readonly();
        }
        public void LastData()
        {
            LIDID = DB1.CorporationProducts.Where(p => p.Activated == true).Max(p => p.ID);
            BindCommand(LIDID);
            Listview1.SelectedIndex = LIDID;
            Readonly();

        }


        protected void btnEditLable_Click(object sender, EventArgs e)
        {
            if (Session["LANGUAGE"].ToString() == "ar-KW")
            {
                if (btnEditLable.Text == "Update Label")
                {

                    //2false
                    lblProductName2h.Visible = lblCategoryID2h.Visible = false;
                    //2true
                    txtProductName2h.Visible = txtCategoryID2h.Visible = true;

                    //header
                    lblHeader.Visible = false;
                    txtHeader.Visible = true;
                    btnEditLable.Text = "Save Label";
                }
                else
                {
                    SaveLabel(Session["LANGUAGE"].ToString());

                    ManageLang();
                    btnEditLable.Text = "Update Label";
                    //2true
                    lblProductName2h.Visible = lblCategoryID2h.Visible = true;
                    //2false
                    txtProductName2h.Visible = txtCategoryID2h.Visible = false;

                    //header
                    lblHeader.Visible = true;
                    txtHeader.Visible = false;
                }
            }
            else
            {
                if (btnEditLable.Text == "Update Label")
                {
                    //1false
                    lblProductName1s.Visible = lblCategoryID1s.Visible = false;
                    //1true
                    txtProductName1s.Visible = txtCategoryID1s.Visible = true;
                    //header
                    lblHeader.Visible = false;
                    txtHeader.Visible = true;
                    btnEditLable.Text = "Save Label";
                }
                else
                {
                    SaveLabel(Session["LANGUAGE"].ToString());
                    ManageLang();
                    btnEditLable.Text = "Update Label";
                    //1true
                    lblProductName1s.Visible = lblCategoryID1s.Visible = true;
                    //1false
                    txtProductName1s.Visible = txtCategoryID1s.Visible = false;
                    //header
                    lblHeader.Visible = true;
                    txtHeader.Visible = false;
                }
            }
        }
        public void RecieveLabel(string lang)
        {
            string str = "";
            string PID = ((ACMMaster)this.Master).getOwnPage();

            List<Database.ACM_TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("CorporationProduct").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            foreach (Database.ACM_TBLLabelDTL item in List)
            {
                
                if (lblProductName1s.ID == item.LabelID)
                    txtProductName1s.Text = lblProductName1s.Text =  item.LabelName;
                else if (lblCategoryID1s.ID == item.LabelID)
                    txtCategoryID1s.Text = lblCategoryID1s.Text = item.LabelName;
               

               
                else if (lblProductName2h.ID == item.LabelID)
                    txtProductName2h.Text = lblProductName2h.Text =  item.LabelName;
                else if (lblCategoryID2h.ID == item.LabelID)
                    txtCategoryID2h.Text = lblCategoryID2h.Text =  item.LabelName;
                

                else
                    txtHeader.Text = lblHeader.Text = Label5.Text = item.LabelName;
            }

        }
        public void SaveLabel(string lang)
        {
            string PID = ((ACMMaster)this.Master).getOwnPage();
            //List<Database.TBLLabelDTL> List = DB.TBLLabelDTLs.Where(p => p.LabelMstID == PID  && p.LANGDISP == lang).ToList();
            List<Database.ACM_TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("CorporationProduct").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("\\ACM\\xml\\CorporationProduct.xml"));
            foreach (Database.ACM_TBLLabelDTL item in List)
            {

                var obj = ((ACMMaster)this.Master).Bindxml("CorporationProduct").Single(p => p.LabelID == item.LabelID && p.LabelMstID == PID && p.LANGDISP == lang);
                int i = obj.ID - 1;

               
                if (lblProductName1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtProductName1s.Text;
                else if (lblCategoryID1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCategoryID1s.Text;
               

                
                else if (lblProductName2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtProductName2h.Text;
                else if (lblCategoryID2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCategoryID2h.Text;
               

                else
                    ds.Tables[0].Rows[i]["LabelName"] = txtHeader.Text;
            }
            ds.WriteXml(Server.MapPath("\\ACM\\xml\\CorporationProduct.xml"));

        }

        public void ManageLang()
        {
            //for Language

            if (Session["LANGUAGE"] != null)
            {
                RecieveLabel(Session["LANGUAGE"].ToString());
                if (Session["LANGUAGE"].ToString() == "ar-KW")
                    GetHide();
                else
                    GetShow();
            }

        }
        protected void LanguageFrance_Click(object sender, EventArgs e)
        {
            Session["LANGUAGE"] = "fr-FR";
            ManageLang();
        }
        protected void LanguageArabic_Click(object sender, EventArgs e)
        {
            Session["LANGUAGE"] = "ar-KW";
            ManageLang();
        }
        protected void LanguageEnglish_Click(object sender, EventArgs e)
        {
            Session["LANGUAGE"] = "en-US";
            ManageLang();
        }
        public void Write()
        {
            //navigation.Visible = false;
            txtProductName.Enabled = true;
            drpCategoryID.Enabled = true;
            //cbActivated.Enabled = true;
            //cbDeleted.Enabled = true;
            //txtDateTime.Enabled = true;
            //drpCreatedBy.Enabled = true;

        }
        public void Readonly()
        {
            //navigation.Visible = true;
            txtProductName.Enabled = false;
            drpCategoryID.Enabled = false;
            //cbActivated.Enabled = false;
            //cbDeleted.Enabled = false;
            //txtDateTime.Enabled = false;
            //drpCreatedBy.Enabled = false;


        }

        #region Listview
        protected void btnNext1_Click(object sender, EventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = DB1.CorporationProducts.Count();
            if (ViewState["Take"] == null && ViewState["Skip"] == null)
            {
                ViewState["Take"] = Showdata;
                ViewState["Skip"] = 0;
            }
            take = Convert.ToInt32(ViewState["Take"]);
            take = take + Showdata;
            Skip = take - Showdata;

            ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorporationProducts.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
            ViewState["Take"] = take;
            ViewState["Skip"] = Skip;
            if (take == Totalrec && Skip == (Totalrec - Showdata))
                btnNext1.Enabled = false;
            else
                btnNext1.Enabled = true;
            if (take == Showdata && Skip == 0)
                btnPrevious1.Enabled = false;
            else
                btnPrevious1.Enabled = true;

            ChoiceID = take / Showdata;

            ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2);
            lblShowinfEntry.Text = "Showing " + Skip + " to " + take + " of " + Totalrec + " entries";

        }
        protected void btnPrevious1_Click(object sender, EventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            if (ViewState["Take"] != null && ViewState["Skip"] != null)
            {
                int Totalrec = DB1.CorporationProducts.Count();
                Skip = Convert.ToInt32(ViewState["Skip"]);
                take = Skip;
                Skip = take - Showdata;
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorporationProducts.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
                ViewState["Take"] = take;
                ViewState["Skip"] = Skip;
                if (take == Showdata && Skip == 0)
                    btnPrevious1.Enabled = false;
                else
                    btnPrevious1.Enabled = true;

                if (take == Totalrec && Skip == (Totalrec - Showdata))
                    btnNext1.Enabled = false;
                else
                    btnNext1.Enabled = true;

                ChoiceID = take / Showdata;
                ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2);
                lblShowinfEntry.Text = "Showing " + Skip + " to " + take + " of " + Totalrec + " entries";
            }
        }
        protected void btnfirst_Click(object sender, EventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            if (ViewState["Take"] != null && ViewState["Skip"] != null)
            {
                int Totalrec = DB1.CorporationProducts.Count();
                take = Showdata;
                Skip = 0;
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorporationProducts.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
                ViewState["Take"] = take;
                ViewState["Skip"] = Skip;
                btnPrevious1.Enabled = false;
                ChoiceID = 0;
                ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2);
                if (take == Totalrec && Skip == (Totalrec - Showdata))
                    btnNext1.Enabled = false;
                else
                    btnNext1.Enabled = true;
                lblShowinfEntry.Text = "Showing " + Skip + " to " + take + " of " + Totalrec + " entries";

            }
        }
        protected void btnLast1_Click(object sender, EventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = DB1.CorporationProducts.Count();
            take = Totalrec;
            Skip = Totalrec - Showdata;
            ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorporationProducts.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
            ViewState["Take"] = take;
            ViewState["Skip"] = Skip;
            btnNext1.Enabled = false;
            btnPrevious1.Enabled = true;
            ChoiceID = take / Showdata;
            ((ACMMaster)Page.Master).GetCurrentNavigationLast(ChoiceID, Showdata, ListView2);
            lblShowinfEntry.Text = "Showing " + ViewState["Skip"].ToString() + " to " + ViewState["Take"].ToString() + " of " + Totalrec + " entries";
        }
        protected void btnlistreload_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnPagereload_Click(object sender, EventArgs e)
        {
            Readonly();
            ManageLang();
            pnlSuccessMsg.Visible = false;
            FillContractorID();
            int CurrentID = 1;
            if (ViewState["Es"] != null)
                CurrentID = Convert.ToInt32(ViewState["Es"]);
            BindData();
            FirstData();
        }


        protected void Listview1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (e.CommandName == "btnDelete")
                    {

                        int TID = Convert.ToInt32(e.CommandArgument);

                        Database.CorporationProduct objSOJobDesc = DB1.CorporationProducts.Single(p => p.ID == TID);
                        objSOJobDesc.Activated = false;
                        DB.SaveChanges();
                        BindData();
                        int Tvalue = Convert.ToInt32(ViewState["Take"]);
                        int Svalue = Convert.ToInt32(ViewState["Skip"]);
                        ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorporationProducts.OrderBy(m => m.ID).Take(Tvalue).Skip(Svalue)).ToList());

                    }

                    if (e.CommandName == "btnEdit")
                    {
                        int TID1 = Convert.ToInt32(e.CommandArgument);
                        BindCommand(TID1);
                        btnAdd.Text = "Update";
                        Write();
                    }
                    scope.Complete(); //  To commit.
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", ex.Message, true);
                    throw;
                }
            }
        }
        public void BindCommand(int TID)
        {
            Database.CorporationProduct objCorporationProduct = DB1.CorporationProducts.Single(p => p.ID == TID);
            txtProductName.Text = objCorporationProduct.ProductName.ToString();
            drpCategoryID.SelectedValue = objCorporationProduct.CategoryID.ToString();
            ViewState["Edit"] = TID;
        }
        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = DB1.CorporationProducts.Count();
            if (e.CommandName == "LinkPageavigation")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                ViewState["Take"] = ID * Showdata;
                ViewState["Skip"] = (ID * Showdata) - Showdata;
                int Tvalue = Convert.ToInt32(ViewState["Take"]);
                int Svalue = Convert.ToInt32(ViewState["Skip"]);
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorporationProducts.OrderBy(m => m.ID).Take(Tvalue).Skip(Svalue)).ToList());
                ChoiceID = ID;
                ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2);
                if (Tvalue == Showdata && Svalue == 0)
                    btnPrevious1.Enabled = false;
                else
                    btnPrevious1.Enabled = true;
                if (take == Totalrec && Skip == (Totalrec - Showdata))
                    btnNext1.Enabled = false;
                else
                    btnNext1.Enabled = true;
            }
            lblShowinfEntry.Text = "Showing " + ViewState["Skip"].ToString() + " to " + ViewState["Take"].ToString() + " of " + Totalrec + " entries";


        }

        protected void drpShowGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void AnswerList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            LinkButton lb = e.Item.FindControl("LinkPageavigation") as LinkButton;
            ScriptManager control = this.Master.FindControl("toolscriptmanagerID") as ScriptManager;
            control.RegisterAsyncPostBackControl(lb);  // ToolkitScriptManager
        }
        #endregion

    }
}