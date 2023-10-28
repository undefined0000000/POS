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
    public partial class Technology : System.Web.UI.Page
    {
        #region Step1
        int count = 0;
        int take = 0;
        int Skip = 0;
        public static int ChoiceID = 0;
        #endregion
        ERPEntities DB = new ERPEntities();
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
            var List = DB1.Technologies.OrderByDescending(m => m.ID).ToList();
            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = List.Count();
            ((ACMMaster)Page.Master).Loadlist(Showdata, take, Skip, ChoiceID, lblShowinfEntry, btnPrevious1, btnNext1, Listview1, ListView2, Totalrec, List);
        }
        #endregion

        public void GetShow()
        {

            lblPageName1s.Attributes["class"] = lblPageTitle1s.Attributes["class"] = lblMetaDescription1s.Attributes["class"] = lblMetaKeyword1s.Attributes["class"] = lblPageContent1s.Attributes["class"] = lblImage1s.Attributes["class"] = "control-label col-md-4  getshow";
            lblPageName2h.Attributes["class"] = lblPageTitle2h.Attributes["class"] = lblMetaDescription2h.Attributes["class"] = lblMetaKeyword2h.Attributes["class"] = lblPageContent2h.Attributes["class"] = lblImage2h.Attributes["class"] = "control-label col-md-4  gethide";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "ltr");

        }

        public void GetHide()
        {
            lblPageName1s.Attributes["class"] = lblPageTitle1s.Attributes["class"] = lblMetaDescription1s.Attributes["class"] = lblMetaKeyword1s.Attributes["class"] = lblPageContent1s.Attributes["class"] = lblImage1s.Attributes["class"] = "control-label col-md-4  gethide";
            lblPageName2h.Attributes["class"] = lblPageTitle2h.Attributes["class"] = lblMetaDescription2h.Attributes["class"] = lblMetaKeyword2h.Attributes["class"] = lblPageContent2h.Attributes["class"] = lblImage2h.Attributes["class"] = "control-label col-md-4  getshow";
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
            txtPageName.Text = "";
            txtPageTitle.Text = "";
            txtMetaDescription.Text = "";
            txtMetaKeyword.Text = "";
            txtPageContent.Text = "";


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
                    }
                    else if (btnAdd.Text == "Add")
                    {
                        Database.Technology objTechnology = new Database.Technology();
                        //Server Content Send data Yogesh
                        objTechnology.PageName = txtPageName.Text;
                        objTechnology.PageTitle = txtPageTitle.Text;
                        objTechnology.MetaDescription = txtMetaDescription.Text;
                        objTechnology.MetaKeyword = txtMetaKeyword.Text;
                        objTechnology.PageContent = txtPageContent.Text;
                        if (uploadimg.HasFile)
                        {

                            uploadimg.SaveAs(Server.MapPath("~/Gallery/") + uploadimg.FileName);
                            objTechnology.Image = uploadimg.FileName;

                        }
                        //objTechnology.Image = txtImage.Text;
                        objTechnology.Actived = true;
                        objTechnology.Deleted = true;
                        objTechnology.CreatedDate = DateTime.Now;


                        DB1.Technologies.AddObject(objTechnology);
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
                            int ID1 = Convert.ToInt32(ViewState["Edit"]);
                            Database.Technology objTechnology = DB1.Technologies.Single(p => p.ID == ID1);
                            objTechnology.PageName = txtPageName.Text;
                            objTechnology.PageTitle = txtPageTitle.Text;
                            objTechnology.MetaDescription = txtMetaDescription.Text;
                            objTechnology.MetaKeyword = txtMetaKeyword.Text;
                            objTechnology.PageContent = txtPageContent.Text;
                            if (uploadimg.HasFile)
                            {

                                uploadimg.SaveAs(Server.MapPath("~/Gallery/") + uploadimg.FileName);
                                objTechnology.Image = uploadimg.FileName;

                            }
                            

                            ViewState["Edit"] = null;
                            btnAdd.Text = "AddNew";
                            DB1.SaveChanges();
                            Clear();
                            lblMsg.Text = "  Data Edit Successfully";
                            pnlSuccessMsg.Visible = true;
                            BindData();
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
            Response.Redirect("Technology.aspx");
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
            LIDID = DB1.Technologies.Where(p => p.Actived == true).FirstOrDefault().ID;
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
            Listview1.SelectedIndex = LIDID;
            BindCommand(LIDID);
            Readonly();
        }
        public void LastData()
        {
            LIDID = DB1.Technologies.Where(p => p.Actived == true).Max(p => p.ID);
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
                    lblPageName2h.Visible = lblPageTitle2h.Visible = lblMetaDescription2h.Visible = lblMetaKeyword2h.Visible = lblPageContent2h.Visible = lblImage2h.Visible = false;
                    //2true
                    txtPageName2h.Visible = txtPageTitle2h.Visible = txtMetaDescription2h.Visible = txtMetaKeyword2h.Visible = txtPageContent2h.Visible = txtImage2h.Visible = true;

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
                    lblPageName2h.Visible = lblPageTitle2h.Visible = lblMetaDescription2h.Visible = lblMetaKeyword2h.Visible = lblPageContent2h.Visible = lblImage2h.Visible = true;
                    //2false
                    txtPageName2h.Visible = txtPageTitle2h.Visible = txtMetaDescription2h.Visible = txtMetaKeyword2h.Visible = txtPageContent2h.Visible = txtImage2h.Visible = false;

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
                    lblPageName1s.Visible = lblPageTitle1s.Visible = lblMetaDescription1s.Visible = lblMetaKeyword1s.Visible = lblPageContent1s.Visible = lblImage1s.Visible = false;
                    //1true
                    txtPageName1s.Visible = txtPageTitle1s.Visible = txtMetaDescription1s.Visible = txtMetaKeyword1s.Visible = txtPageContent1s.Visible = txtImage1s.Visible = true;
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
                    lblPageName1s.Visible = lblPageTitle1s.Visible = lblMetaDescription1s.Visible = lblMetaKeyword1s.Visible = lblPageContent1s.Visible = lblImage1s.Visible = true;
                    //1false
                    txtPageName1s.Visible = txtPageTitle1s.Visible = txtMetaDescription1s.Visible = txtMetaKeyword1s.Visible = txtPageContent1s.Visible = txtImage1s.Visible = false;
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

            List<Database.ACM_TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("Technology").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            foreach (Database.ACM_TBLLabelDTL item in List)
            {
                if (lblPageName1s.ID == item.LabelID)
                    txtPageName1s.Text = lblPageName1s.Text = item.LabelName;
                else if (lblPageTitle1s.ID == item.LabelID)
                    txtPageTitle1s.Text = lblPageTitle1s.Text = item.LabelName;
                else if (lblMetaDescription1s.ID == item.LabelID)
                    txtMetaDescription1s.Text = lblMetaDescription1s.Text = item.LabelName;
                else if (lblMetaKeyword1s.ID == item.LabelID)
                    txtMetaKeyword1s.Text = lblMetaKeyword1s.Text =  item.LabelName;
                else if (lblPageContent1s.ID == item.LabelID)
                    txtPageContent1s.Text = lblPageContent1s.Text = item.LabelName;
                else if (lblImage1s.ID == item.LabelID)
                    txtImage1s.Text = lblImage1s.Text = item.LabelName;

                if (lblPageName2h.ID == item.LabelID)
                    txtPageName2h.Text = lblPageName2h.Text =  item.LabelName;
                else if (lblPageTitle2h.ID == item.LabelID)
                    txtPageTitle2h.Text = lblPageTitle2h.Text = item.LabelName;
                else if (lblMetaDescription2h.ID == item.LabelID)
                    txtMetaDescription2h.Text = lblMetaDescription2h.Text =  item.LabelName;
                else if (lblMetaKeyword2h.ID == item.LabelID)
                    txtMetaKeyword2h.Text = lblMetaKeyword2h.Text =  item.LabelName;
                else if (lblPageContent2h.ID == item.LabelID)
                    txtPageContent2h.Text = lblPageContent2h.Text =  item.LabelName;
                else if (lblImage2h.ID == item.LabelID)
                    txtImage2h.Text = lblImage2h.Text =  item.LabelName;

                else
                    txtHeader.Text = lblHeader.Text = Label5.Text = item.LabelName;
            }

        }
        public void SaveLabel(string lang)
        {
            string PID = ((ACMMaster)this.Master).getOwnPage();
            //List<Database.TBLLabelDTL> List = DB.TBLLabelDTLs.Where(p => p.LabelMstID == PID  && p.LANGDISP == lang).ToList();
            List<Database.ACM_TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("Technology").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("\\ACM\\xml\\Technology.xml"));
            foreach (Database.ACM_TBLLabelDTL item in List)
            {

                var obj = ((ACMMaster)this.Master).Bindxml("Technology").Single(p => p.LabelID == item.LabelID && p.LabelMstID == PID && p.LANGDISP == lang);
                int i = obj.ID - 1;

                if (lblPageName1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPageName1s.Text;
                else if (lblPageTitle1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPageTitle1s.Text;
                else if (lblMetaDescription1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMetaDescription1s.Text;
                else if (lblMetaKeyword1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMetaKeyword1s.Text;
                else if (lblPageContent1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPageContent1s.Text;
                else if (lblImage1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtImage1s.Text;

                if (lblPageName2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPageName2h.Text;
                else if (lblPageTitle2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPageTitle2h.Text;
                else if (lblMetaDescription2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMetaDescription2h.Text;
                else if (lblMetaKeyword2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMetaKeyword2h.Text;
                else if (lblPageContent2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPageContent2h.Text;
                else if (lblImage2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtImage2h.Text;

                else
                    ds.Tables[0].Rows[i]["LabelName"] = txtHeader.Text;
            }
            ds.WriteXml(Server.MapPath("\\xml\\Technology.xml"));

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
            txtPageName.Enabled = true;
            txtPageTitle.Enabled = true;
            txtMetaDescription.Enabled = true;
            txtMetaKeyword.Enabled = true;
            txtPageContent.Enabled = true;
            //txtImage.Enabled = true;
            
        }
        public void Readonly()
        {
            //navigation.Visible = true;
            txtPageName.Enabled = false;
            txtPageTitle.Enabled = false;
            txtMetaDescription.Enabled = false;
            txtMetaKeyword.Enabled = false;
            txtPageContent.Enabled = false;
            //txtImage.Enabled = false;
            


        }

        #region Listview
        protected void btnNext1_Click(object sender, EventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = DB1.Technologies.Count();
            if (ViewState["Take"] == null && ViewState["Skip"] == null)
            {
                ViewState["Take"] = Showdata;
                ViewState["Skip"] = 0;
            }
            take = Convert.ToInt32(ViewState["Take"]);
            take = take + Showdata;
            Skip = take - Showdata;

            ((ACMMaster)Page.Master).BindList(Listview1, (DB1.Technologies.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
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
                int Totalrec = DB1.Technologies.Count();
                Skip = Convert.ToInt32(ViewState["Skip"]);
                take = Skip;
                Skip = take - Showdata;
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.Technologies.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
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
                int Totalrec = DB1.Technologies.Count();
                take = Showdata;
                Skip = 0;
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.Technologies.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
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
            int Totalrec = DB1.Technologies.Count();
            take = Totalrec;
            Skip = Totalrec - Showdata;
            ((ACMMaster)Page.Master).BindList(Listview1, (DB1.Technologies.OrderBy(m => m.ID).Take(take).Skip(Skip)).ToList());
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

                        int id = Convert.ToInt32(e.CommandArgument);

                        Database.Technology objSOJobDesc = DB1.Technologies.Single(p => p.ID == id);
                        objSOJobDesc.Actived = false;
                        DB.SaveChanges();
                        BindData();
                        int Tvalue = Convert.ToInt32(ViewState["Take"]);
                        int Svalue = Convert.ToInt32(ViewState["Skip"]);
                        ((ACMMaster)Page.Master).BindList(Listview1, (DB1.Technologies.OrderBy(m => m.ID).Take(Tvalue).Skip(Svalue)).ToList());

                    }

                    if (e.CommandName == "btnEdit")
                    {
                        int id = Convert.ToInt32(e.CommandArgument);
                        BindCommand(id);
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
        
        public void BindCommand(int id)
        {
            Database.Technology objTechnology = DB1.Technologies.Single(p => p.ID == id);
            txtPageName.Text = objTechnology.PageName.ToString();
            txtPageTitle.Text = objTechnology.PageTitle.ToString();
            txtMetaDescription.Text = objTechnology.MetaDescription.ToString();
            txtMetaKeyword.Text = objTechnology.MetaKeyword.ToString();
            txtPageContent.Text = objTechnology.PageContent.ToString();
           
            ViewState["Edit"] = id;
        }

        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = DB1.Technologies.Count();
            if (e.CommandName == "LinkPageavigation")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                ViewState["Take"] = ID * Showdata;
                ViewState["Skip"] = (ID * Showdata) - Showdata;
                int Tvalue = Convert.ToInt32(ViewState["Take"]);
                int Svalue = Convert.ToInt32(ViewState["Skip"]);
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.Technologies.OrderBy(m => m.ID).Take(Tvalue).Skip(Svalue)).ToList());
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