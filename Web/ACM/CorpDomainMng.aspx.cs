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
    public partial class CorpDomainMng : System.Web.UI.Page
    {
        #region Step1
        int count = 0;
        int take = 0;
        int Skip = 0;
        public static int ChoiceID = 0;
        #endregion
        CallEntities DB1 = new CallEntities();
        ERPEntities DB = new ERPEntities();
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
               
                //FirstData();
               
            }
        }
        #region Step2
        public void BindData()
        {
            var List = DB1.CorpDomainMngs.Where(P => P.DeletedBy == true).OrderByDescending(p => p.TID).ToList();

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = List.Count();
            ((ACMMaster)Page.Master).Loadlist(Showdata, take, Skip, ChoiceID, lblShowinfEntry, btnPrevious1, btnNext1, Listview1, ListView2, Totalrec, List);
        }
        #endregion

        public void GetShow()
        {

            lblType1s.Attributes["class"] = lblName11s.Attributes["class"] = lblName21s.Attributes["class"] = lblName31s.Attributes["class"] = lblURL1s.Attributes["class"] = lblParameter2h.Attributes["class"] = lblSortBy1s.Attributes["class"] = lblPublicY1s.Attributes["class"] = lblActive1s.Attributes["class"] = "control-label col-md-4  getshow";
            lblType2h.Attributes["class"] = lblName12h.Attributes["class"] = lblName22h.Attributes["class"] = lblName32h.Attributes["class"] = lblURL2h.Attributes["class"] = lblParameter2h.Attributes["class"] = lblSortBy2h.Attributes["class"] = lblPublicY2h.Attributes["class"] = lblActive2h.Attributes["class"] = "control-label col-md-4  gethide";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "ltr");

        }

        public void GetHide()
        {
            lblType1s.Attributes["class"] = lblName11s.Attributes["class"] = lblName21s.Attributes["class"] = lblName31s.Attributes["class"] = lblURL1s.Attributes["class"] = lblParameter2h.Attributes["class"] = lblSortBy1s.Attributes["class"] = lblPublicY1s.Attributes["class"] = lblActive1s.Attributes["class"] = "control-label col-md-4  gethide";
            lblType2h.Attributes["class"] = lblName12h.Attributes["class"] = lblName22h.Attributes["class"] = lblName32h.Attributes["class"] = lblURL2h.Attributes["class"] = lblParameter2h.Attributes["class"] = lblSortBy2h.Attributes["class"] = lblPublicY2h.Attributes["class"] = lblActive2h.Attributes["class"] = "control-label col-md-4  getshow";
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
            drpType.SelectedIndex = 0;
            txtName1.Text = "";
            txtName2.Text = "";
            txtName3.Text = "";
            txtURL.Text = "";
            drpParameter.SelectedIndex = 0;
            drpSortBy.SelectedIndex = 0;
           

            //txtPublicY1s.Text = "";
            //txtActive1s.Text = "";

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
                        Database.CorpDomainMng objCorpDomainMng = new Database.CorpDomainMng();
                        //Server Content Send data Yogesh
                        objCorpDomainMng.Type = Convert.ToInt32(drpType.SelectedValue);
                        objCorpDomainMng.Name1 = txtName1.Text;
                        objCorpDomainMng.Name2 = txtName2.Text;
                        objCorpDomainMng.Name3 = txtName3.Text;
                        objCorpDomainMng.URL = txtURL.Text;
                        if (drpParameter.SelectedValue != "0")
                        {
                            objCorpDomainMng.Parameter = Convert.ToInt32(drpParameter.SelectedValue);
                        }
                        if (drpSortBy.SelectedValue != "0")
                        {
                            objCorpDomainMng.SortBy = Convert.ToInt32(drpSortBy.SelectedValue);
                        }
                        objCorpDomainMng.PublicY = cbPublicY.Checked;
                        objCorpDomainMng.Active = cbActive.Checked;
                        objCorpDomainMng.DeletedBy = true;
                       

                        DB1.CorpDomainMngs.AddObject(objCorpDomainMng);
                        DB1.SaveChanges();
                        Clear();
                        lblMsg.Text = "  Data Save Successfully";
                        pnlSuccessMsg.Visible = true;
                        BindData();
                        LastData();
                        btnAdd.Text = "AddNew";
                        //Navigation.Visible = true;
                        Readonly();
                        //FirstData();
                    }
                    else if (btnAdd.Text == "Update")
                    {

                        if (ViewState["Edit"] != null)
                        {
                            int ID = Convert.ToInt32(ViewState["Edit"]);
                            Database.CorpDomainMng objCorpDomainMng = DB1.CorpDomainMngs.Single(p => p.TID == ID);
                            objCorpDomainMng.Type = Convert.ToInt32(drpType.SelectedValue);
                            objCorpDomainMng.Name1 = txtName1.Text;
                            objCorpDomainMng.Name2 = txtName2.Text;
                            objCorpDomainMng.Name3 = txtName3.Text;
                            objCorpDomainMng.URL = txtURL.Text;
                            if (drpParameter.SelectedValue != "0")
                            {
                                objCorpDomainMng.Parameter = Convert.ToInt32(drpParameter.SelectedValue);
                            }
                            if (drpSortBy.SelectedValue != "0")
                            {
                                objCorpDomainMng.SortBy = Convert.ToInt32(drpSortBy.SelectedValue);
                            }
                            objCorpDomainMng.PublicY = cbPublicY.Checked;
                            objCorpDomainMng.Active = cbActive.Checked;
                            
                            ViewState["Edit"] = null;
                            btnAdd.ValidationGroup = "submit";
                            btnAdd.Text = "AddNew";
                            DB1.SaveChanges();
                            Clear();
                            lblMsg.Text = "  Data Edit Successfully";
                            pnlSuccessMsg.Visible = true;
                            BindData();
                            LastData();
                            //navigation.Visible = true;
                            Readonly();
                            //FirstData();
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
            Clear();
            Readonly();
            LastData();
            Response.Redirect("CorpDomainMng.aspx");
            btnAdd.Text = "AddNew";
            //Response.Redirect(Session["Previous"].ToString());
        }
        public void FillContractorID()
        {
            //drpActive.Items.Insert(0, new ListItem("-- Select --", "0"));drpActive.DataSource = DB.0;drpActive.DataTextField = "0";drpActive.DataValueField = "0";drpActive.DataBind();
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
            LIDID = DB1.CorpDomainMngs.Where(p => p.Active == true).FirstOrDefault().TID;

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


            LIDID = DB1.CorpDomainMngs.Where(p => p.Active == true).Max(p => p.TID);
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

                    //2false lblTID2h.Visible = 
                    lblType2h.Visible = lblName12h.Visible = lblName22h.Visible = lblName32h.Visible = lblURL2h.Visible = lblParameter2h.Visible = lblSortBy2h.Visible = lblPublicY2h.Visible = lblActive2h.Visible = false;
                    //2true txtTID2h.Visible = 
                    txtType2h.Visible = txtName12h.Visible = txtName22h.Visible = txtName32h.Visible = txtURL2h.Visible = txtParameter2h.Visible = txtSortBy2h.Visible = txtPublicY2h.Visible = txtActive2h.Visible = true;

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
                    //2true lblTID2h.Visible = 
                    lblType2h.Visible = lblName12h.Visible = lblName22h.Visible = lblName32h.Visible = lblURL2h.Visible = lblParameter2h.Visible = lblSortBy2h.Visible = lblPublicY2h.Visible = lblActive2h.Visible = true;
                    //2false txtTID2h.Visible = 
                    txtType2h.Visible = txtName12h.Visible = txtName22h.Visible = txtName32h.Visible = txtURL2h.Visible = txtParameter2h.Visible = txtSortBy2h.Visible = txtPublicY2h.Visible = txtActive2h.Visible = false;

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
                    lblType1s.Visible = lblName11s.Visible = lblName21s.Visible = lblName31s.Visible = lblURL1s.Visible = lblParameter2h.Visible = lblSortBy1s.Visible = lblPublicY1s.Visible = lblActive1s.Visible = false;
                    //1true
                    txtType1s.Visible = txtName11s.Visible = txtName21s.Visible = txtName31s.Visible = txtURL1s.Visible = txtParameter2h.Visible = txtSortBy1s.Visible = txtPublicY1s.Visible = txtActive1s.Visible = true;
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
                    lblType1s.Visible = lblName11s.Visible = lblName21s.Visible = lblName31s.Visible = lblURL1s.Visible = lblParameter2h.Visible = lblSortBy1s.Visible = lblPublicY1s.Visible = lblActive1s.Visible = true;
                    //1false
                    txtType1s.Visible = txtName11s.Visible = txtName21s.Visible = txtName31s.Visible = txtURL1s.Visible = txtParameter2h.Visible = txtSortBy1s.Visible = txtPublicY1s.Visible = txtActive1s.Visible = false;
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

            List<Database.ACM_TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("CorpDomainMng").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            foreach (Database.ACM_TBLLabelDTL item in List)
            {
                //if (lblTID1s.ID == item.LabelID)
                //    txtTID1s.Text = lblTID1s.Text = item.LabelName;
                 if (lblType1s.ID == item.LabelID)
                    txtType1s.Text = lblType1s.Text =  item.LabelName;
                else if (lblName11s.ID == item.LabelID)
                    txtName11s.Text = lblName11s.Text =  item.LabelName;
                else if (lblURL1s.ID == item.LabelID)
                    txtURL1s.Text = lblURL1s.Text =  item.LabelName;
                else if (lblParameter2h.ID == item.LabelID)
                    txtParameter2h.Text = lblParameter2h.Text =  item.LabelName;
                else if (lblName21s.ID == item.LabelID)
                    txtName21s.Text = lblName21s.Text = item.LabelName;
                else if (lblName31s.ID == item.LabelID)
                    txtName31s.Text = lblName31s.Text = item.LabelName;

                else if (lblSortBy1s.ID == item.LabelID)
                    txtSortBy1s.Text = lblSortBy1s.Text =  item.LabelName;
                else if (lblPublicY1s.ID == item.LabelID)
                    txtPublicY1s.Text = lblPublicY1s.Text =  item.LabelName;
                else if (lblActive1s.ID == item.LabelID)
                    txtActive1s.Text = lblActive1s.Text =  item.LabelName;

                //else if (lblTID2h.ID == item.LabelID)
                 //    txtTID2h.Text = lblTID2h.Text =  item.LabelName;
                else if (lblType2h.ID == item.LabelID)
                    txtType2h.Text = lblType2h.Text =  item.LabelName;
                else if (lblName12h.ID == item.LabelID)
                    txtName12h.Text = lblName12h.Text =  item.LabelName;
                else if (lblParameter2h.ID == item.LabelID)
                    txtParameter2h.Text = lblParameter2h.Text =  item.LabelName;


                else if (lblName22h.ID == item.LabelID)
                    txtName22h.Text = lblName22h.Text =  item.LabelName;
                else if (lblName32h.ID == item.LabelID)
                    txtName32h.Text = lblName32h.Text =  item.LabelName;
                else if (lblURL2h.ID == item.LabelID)
                    txtURL2h.Text = lblURL2h.Text = item.LabelName;

                else if (lblSortBy2h.ID == item.LabelID)
                    txtSortBy2h.Text = lblSortBy2h.Text = item.LabelName;
                else if (lblPublicY2h.ID == item.LabelID)
                    txtPublicY2h.Text = lblPublicY2h.Text =  item.LabelName;
                else if (lblActive2h.ID == item.LabelID)
                    txtActive2h.Text = lblActive2h.Text =  item.LabelName;

                else
                    txtHeader.Text = lblHeader.Text = Label5.Text = item.LabelName;
            }

        }
        public void SaveLabel(string lang)
        {
            string PID = ((ACMMaster)this.Master).getOwnPage();
            //List<Database.TBLLabelDTL> List = DB.TBLLabelDTLs.Where(p => p.LabelMstID == PID  && p.LANGDISP == lang).ToList();
            List<Database.ACM_TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("CorpDomainMng").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("\\ACM\\xml\\CorpDomainMng.xml"));
            foreach (Database.ACM_TBLLabelDTL item in List)
            {

                var obj = ((ACMMaster)this.Master).Bindxml("CorpDomainMng").Single(p => p.LabelID == item.LabelID && p.LabelMstID == PID && p.LANGDISP == lang);
                int i = obj.ID - 1;

                //if (lblTID1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtTID1s.Text;
                if (lblType1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtType1s.Text;
                else if (lblName11s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtName11s.Text;
                else if (lblName21s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtName21s.Text;
                else if (lblName31s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtName31s.Text;
                else if (lblURL1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtURL1s.Text;
                else if (lblParameter2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtParameter2h.Text;
                else if (lblSortBy1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSortBy1s.Text;
                else if (lblPublicY1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPublicY1s.Text;
                else if (lblActive1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtActive1s.Text;

                //else if (lblTID2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtTID2h.Text;
                else if (lblType2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtType2h.Text;
                else if (lblName12h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtName12h.Text;
                else if (lblName22h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtName22h.Text;
                else if (lblName32h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtName32h.Text;
                else if (lblURL2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtURL2h.Text;
                else if (lblParameter2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtParameter2h.Text;
                else if (lblSortBy2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSortBy2h.Text;
                else if (lblPublicY2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPublicY2h.Text;
                else if (lblActive2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtActive2h.Text;

                else
                    ds.Tables[0].Rows[i]["LabelName"] = txtHeader.Text;
            }
            ds.WriteXml(Server.MapPath("\\ACM\\xml\\CorpDomainMng.xml"));

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
            drpType.Enabled = true;
            txtName1.Enabled = true;
            txtName2.Enabled = true;
            txtName3.Enabled = true;
            txtURL.Enabled = true;
            drpParameter.Enabled = true;
            drpSortBy.Enabled = true;
            cbPublicY.Enabled = true;
            cbActive.Enabled = true;

        }
        public void Readonly()
        {
            //navigation.Visible = true;
            drpType.Enabled = false;
            txtName1.Enabled = false;
            txtName2.Enabled = false;
            txtName3.Enabled = false;
            txtURL.Enabled = false;
            drpParameter.Enabled = false;
            drpSortBy.Enabled = false;
            cbPublicY.Enabled = false;
            cbActive.Enabled = false;


        }

        #region Listview
        protected void btnNext1_Click(object sender, EventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = DB1.CorpDomainMngs.Count();
            if (ViewState["Take"] == null && ViewState["Skip"] == null)
            {
                ViewState["Take"] = Showdata;
                ViewState["Skip"] = 0;
            }
            take = Convert.ToInt32(ViewState["Take"]);
            take = take + Showdata;
            Skip = take - Showdata;

            ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorpDomainMngs.OrderBy(m => m.TID).Take(take).Skip(Skip)).ToList());
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
                int Totalrec = DB1.CorpDomainMngs.Count();
                Skip = Convert.ToInt32(ViewState["Skip"]);
                take = Skip;
                Skip = take - Showdata;
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorpDomainMngs.OrderBy(m => m.TID).Take(take).Skip(Skip)).ToList());
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
                int Totalrec = DB1.CorpDomainMngs.Count();
                take = Showdata;
                Skip = 0;
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorpDomainMngs.OrderBy(m => m.TID).Take(take).Skip(Skip)).ToList());
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
            int Totalrec = DB1.CorpDomainMngs.Count();
            take = Totalrec;
            Skip = Totalrec - Showdata;
            ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorpDomainMngs.OrderBy(m => m.TID).Take(take).Skip(Skip)).ToList());
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
                if (e.CommandName == "btnView")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    BindCommand(ID);
                    Readonly();
                }

                    if (e.CommandName == "btnDelete")
                    {
                        int ID = Convert.ToInt32(e.CommandArgument);

                        Database.CorpDomainMng obj_corpDomain = DB1.CorpDomainMngs.Single(p => p.TID == ID);
                        obj_corpDomain.DeletedBy = false;
                        DB1.SaveChanges();
                        BindData();
                        LastData();
                       
                    }

                    if (e.CommandName == "btnEdit")
                    {
                        int ID = Convert.ToInt32(e.CommandArgument);
                        BindCommand(ID);
                        btnAdd.Text = "Update";
                       
                        Write();
                        btnAdd.ValidationGroup = "submit";
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

        public string GetDomainType(int ID)
        {
            //ID = 1;
            //string name;
            if (ID == 1)
            {
                return "Technology";
            }
            else if (ID == 2)
            {
                return "Domain";
            }
            else if (ID == 3)
            {
                return "Product";
            }
            return ID.ToString();
        }

        //public string GetDomainType1(string ID)
        //{
        //    string name;
        //    //string sk = Convert.ToInt32(drpType.SelectedItem.Text).ToString();
        //    if (drpType.SelectedItem.Text == "1")
        //    {

        //        drpType.SelectedItem.Text = "Technology";
        //        name = drpType.SelectedItem.Text;
        //        return name;
        //    }
        //    else
        //    {

        //    }
        //}

        public void BindCommand(int ID)
        {
            Database.CorpDomainMng objCorpDomainMng = DB1.CorpDomainMngs.Single(p => p.TID == ID);
            drpType.SelectedValue = objCorpDomainMng.Type.ToString();
            txtName1.Text = objCorpDomainMng.Name1.ToString();
            txtName2.Text = objCorpDomainMng.Name2.ToString();
            txtName3.Text = objCorpDomainMng.Name3.ToString();
            txtURL.Text = objCorpDomainMng.URL.ToString();
            if (objCorpDomainMng.Parameter != null)
            {
                drpParameter.SelectedValue = objCorpDomainMng.Parameter.ToString();
            }
            if (objCorpDomainMng.SortBy != null)
            {
                drpSortBy.SelectedValue = objCorpDomainMng.SortBy.ToString();
            }
            //drpParameter.SelectedItem.Text = objCorpDomainMng.Parameter.ToString();
            //drpSortBy.SelectedItem.Text = objCorpDomainMng.SortBy.ToString();
            cbPublicY.Checked = (objCorpDomainMng.PublicY == true) ? true : false;
            cbActive.Checked = (objCorpDomainMng.Active == true) ? true : false;
            
            //btnAdd.Text = "Update";
            ViewState["Edit"] = ID;
        }
        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            int Totalrec = DB1.CorpDomainMngs.Count();
            if (e.CommandName == "LinkPageavigation")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                ViewState["Take"] = ID * Showdata;
                ViewState["Skip"] = (ID * Showdata) - Showdata;
                int Tvalue = Convert.ToInt32(ViewState["Take"]);
                int Svalue = Convert.ToInt32(ViewState["Skip"]);
                ((ACMMaster)Page.Master).BindList(Listview1, (DB1.CorpDomainMngs.OrderBy(m => m.TID).Take(Tvalue).Skip(Svalue)).ToList());
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