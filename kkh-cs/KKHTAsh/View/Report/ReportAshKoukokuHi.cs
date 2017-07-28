using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Ash.ProcessController.Report;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.Utility;
namespace Isid.KKH.Ash.View.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReportAshKoukokuHi : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region �萔.

        #region ���[.

        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C����.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_KoukokuHi.xlsm";
        /// <summary>
        /// Excel(���[�o�̓}�N���e���v���[�g)�t�@�C����.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_KoukokuHi_Template.xlsx";
        /// <summary>
        /// XML�t�@�C����1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_KoukokuHi_Data.xml";
        /// <summary>
        /// XML�t�@�C����2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_KoukokuHi_Prop.xml";
        /// <summary>
        /// �󔒎��̔}��.
        /// </summary>
        private const String BLANK_SELECTED_VALUE = "ALL";

        #endregion ���[.

        /// <summary>
        /// �A�v��ID.
        /// </summary>
        private const string APLID = "Koukoku";

        #endregion �萔.

        #region �����o�ϐ�.

        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// �����.
        /// </summary>
        private double _dbSyohizei;
        /// <summary>
        /// �ۑ���p(�e���v���[�g)�ϐ�.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// �ۑ���p�ϐ�.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// ���[���i�ۑ��Ŏg�p�j�p�ϐ�.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// �N��.
        /// </summary>
        string yearmon = string.Empty;
        /// <summary>
        /// �f�[�^�Z�b�g.
        /// </summary>
        RepDsAsh AshDs = new RepDsAsh();
        /// <summary>
        /// Xml�p�f�[�^�Z�b�g.
        /// </summary>
        RepDsAsh XmlDs = new RepDsAsh();
        /// <summary>
        /// �폜�p�f�[�^�Z�b�g.
        /// </summary>
        RepDsAsh delDs = new RepDsAsh();
        /// <summary>
        /// �R�s�[�}�N���폜�pstring.
        /// </summary>
        private string _strmacrodel;
        /// <summary>
        /// �c�Ɠ�.
        /// </summary>
        string strDate = string.Empty;
        /// <summary>
        /// ���v�f�[�^��.
        /// </summary>
        string Datagoukei = string.Empty;
        /// <summary>
        /// ���v���z.
        /// </summary>
        string goukeikingak = string.Empty;

        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.

        /// <summary>
        /// 
        /// </summary>
        public ReportAshKoukokuHi()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^.

        #region �C�x���g.

        /// <summary>
        /// ��ʑJ�ڎ�.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAshKoukokuHi_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAshKoukokuHi_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\��.
            base.ShowLoadingDialog();

            //�ҏW.
            EditControl();

            //�}�X�^�f�[�^�̎擾.
            MstDataGet();

            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //����ŃZ�b�g.
                _dbSyohizei = double.Parse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //�e���v���[�g�A�h���X.
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }


            //�ۑ����{���[��.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "003");
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //�ۑ���Z�b�g.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //���̃Z�b�g.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //���[�f�B���O��\��.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// �\���{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            DisplayView();

            //�R���g���[���𖢑I����Ԃɂ���.
            this.ActiveControl = null;
        }

        /// <summary>
        /// �߂�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                // �}�N���t�@�C���̍폜�iVBA���ł͍폜�ł��Ȃ��ׁj.
                // �t�@�C�������݂��Ă��邩���f����.
                if (cFileInfo.Exists)
                {
                    // �ǂݎ���p����������ꍇ�́A�ǂݎ���p��������������.
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    // �t�@�C�����폜����.
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// �G�N�Z���{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {

            btnSrc_Click(new object(), new EventArgs());

            if (this.btnXls.Enabled == true)
            {
                excelDataSet();
            }

            //�R���g���[���𖢑I����Ԃɂ���.
            this.ActiveControl = null;
        }

        /// <summary>
        /// �w���v�{�^���N���b�N����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //���Ӑ�R�[�h.
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);

            //�R���g���[���𖢑I����Ԃɂ���.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpYyyyMmDd_ValueChanged(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
        }

        #endregion �C�x���g.

        #region ���\�b�h.

        /// <summary>
        /// �c�Ɠ��擾.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = string.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        /// <summary>
        /// �e�R���g���[���ҏW.
        /// </summary>
        private void EditControl()
        {
            //�N���̎擾.
            strDate = getHostDate();
            //�X�e�[�^�X�̐ݒ�.
            //txtYyyy.Text = strDate.Substring(0, 4);
            //txtMm.Text = strDate.Substring(4, 2);
            //txtDay.Text = strDate.Substring(6, 2);
            string hostdate = getHostDate();
            dtpYyyyMmDd.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(hostdate);

            //tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //�R���{�{�b�N�X�̐ݒ�.
            CombSet();

        }

        /// <summary>
        /// �X�v���b�h�\��.
        /// </summary>
        private void DisplayView()
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�N���̎擾.
            yearmon = dtpYyyyMmDd.Value.ToString("yyyyMMdd").Substring(0, 6);
            //yearmon = stry + strm;

            //�p�����[�^�̐ݒ�.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;

            //����.
            ReportAshProcessController processcontroller = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processcontroller.findReportKoukokuHi(param);
            if (result.HasError)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();

                return;
            }
            RepDsAsh.RepAshKoukokuHiRow[] resultRow = (RepDsAsh.RepAshKoukokuHiRow[])result.dsAshDataSet.RepAshKoukokuHi.Select("", "");
            //          tslCnt.Text = resultRow.Length.ToString() + " ��";
            lblKensu.Text = resultRow.Length.ToString() + " ��";
            if (resultRow.Length == 0)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();

                //MessageBox.Show("�Y���f�[�^������܂���");.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���[", MessageBoxButtons.OK);
                btnXls.Enabled = false;
                koukokuMain_Sheet1.Rows.Count = 0;
                return;
            }

            AshDs.displayKoukokuHi.Clear();
            AshDs.TvRadioTimeKingak.Clear();

            XmlDs.displayKoukokuHi.Clear();
            XmlDs.allbaitai.Clear();
            //�����o�ϐ��֊i�[.
            AshDs.RepAshKoukokuHi.Merge(result.dsAshDataSet.RepAshKoukokuHi);
            AshDs.TvRadioTimeKingak.Merge(result.dsAshDataSet.TvRadioTimeKingak);

            //�J�E���g�p.
            int count = 0;
            //NO�̐U�蕪���p.
            int SaiNo = 0;
            //�}�̕ʃJ�E���g.
            int BaitaiCount = 0;
            //���v���z.
            double SyoukeiKingak = 0;
            //���v���z.
            double SumKingaku = 0;
            //�O��̔}�̃R�[�h.
            string beforeBaitaiCd = string.Empty;

            foreach (RepDsAsh.RepAshKoukokuHiRow row in resultRow)
            {
                //�f�[�^�ǉ��pRow�̐���.
                RepDsAsh.displayKoukokuHiRow addrow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
                addrow = RowSyokika(addrow);
                if (count == 0)
                {
                    beforeBaitaiCd = row.BaitaiCD.Trim();
                }

                //�O��Ɣ}�̃R�[�h��������珬�v��}��.
                if (!beforeBaitaiCd.Equals(row.BaitaiCD.Trim()))
                {
                    //���vAdd.
                    RepDsAsh.displayKoukokuHiRow SyoukeiRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
                    SyoukeiRow = RowSyokika(SyoukeiRow);
                    SyoukeiRow.SeiKyuNumber = "�f�[�^�����v";
                    SyoukeiRow.Baitai = BaitaiCount.ToString();
                    SyoukeiRow.BaitaiCd = "���v";
                    SyoukeiRow.Kingak = SyoukeiKingak.ToString();
                    AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(SyoukeiRow);
                    //�󔒗p�f�[�^Row��Add.
                    RepDsAsh.displayKoukokuHiRow BlankRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
                    BlankRow = RowSyokika(BlankRow);
                    AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(BlankRow);

                    //Xml�p�ɔ}�̒P�ʂŏ��v���i�[.
                    RepDsAsh.allbaitaiRow XmlSyoukei = XmlDs.allbaitai.NewallbaitaiRow();
                    XmlSyoukei.baitaicd = beforeBaitaiCd;
                    XmlSyoukei.zeinasi = string.Empty;
                    XmlSyoukei.goukei = SyoukeiKingak.ToString();
                    XmlDs.allbaitai.AddallbaitaiRow(XmlSyoukei);

                    BaitaiCount = 0;
                    SyoukeiKingak = 0;
                    beforeBaitaiCd = row.BaitaiCD.Trim();
                }
                //No�i�[.
                if (double.Parse(row.Seikyukin.Trim()) > 0 || count == 0) { SaiNo = SaiNo + 1; }
                int cnt = ++count;
                //addrow.No = cnt.ToString();
                addrow.No = SaiNo.ToString();

                //�������ԍ�.
                addrow.SeiKyuNumber = row.SeikyuNo;
                //�}�̖�.
                addrow.Baitai = BaitaiCdForBaitaiNm(row.BaitaiCD.Trim());

                /* 2014/09/11 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD start */
                //�}�̃R�[�h.
                //addrow.BaitaiCd = row.BaitaiCD.Trim();

                //�}�̃R�[�h�����W�I�X�|�b�g�̏ꍇ.
                if (row.BaitaiCD.Trim().ToString().Equals(KkhConstAsh.BaitaiCd.RADIO_SPOT))
                {
                    //���Ӑ悪�A�T�q�r�[���̏ꍇ.
                    if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                    {
                        addrow.BaitaiCd = KkhConstAsh.BaitaiCd.RADIO_TIME;
                    }
                    else
                    {
                        addrow.BaitaiCd = row.BaitaiCD.Trim();
                    }
                }
                else
                {
                    addrow.BaitaiCd = row.BaitaiCD.Trim();
                }
                /* 2014/09/11 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD end */

                //�������z.
                switch (row.BaitaiCD.Trim())
                {
                    //�e���r�^�C���A���W�I�^�C���A�e���r�l�b�g�X�|�b�g.
                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:   // 2015/06/08 K.F �V�L����ׁ@�A�T�q�Ή�.

                        //                      RepDsAsh.OldKyokuCdRow[] oldDatarow = (RepDsAsh.OldKyokuCdRow[])AshDs.OldKyokuCd.Select("", "");
                        //                      foreach (RepDsAsh.OldKyokuCdRow oldrow in oldDatarow)
                        //                      {
                        //                          //�L�[�ǃR�[�h�Ƌ��Ǐ��̋ǃR�[�h����v������A������\��.
                        //                          if (row.Keykyoku.Trim().Equals(oldrow.Field1))
                        //                          {
                        //                              addrow.Kingak = SeiGakVisible(row.JYUTNO.Trim(), row.JYMEINO.Trim(), row.URMEINO.Trim(), row.HinsyuCD.Trim());
                        //
                        //                              break;
                        //                          }
                        //                          else
                        //                          {
                        if (row.Keykyoku.Trim().Equals(row.KyokuRyaku.Trim()))
                        {
                            addrow.Kingak = SeiGakVisible(row.JYUTNO.Trim(), row.JYMEINO.Trim(), row.URMEINO.Trim(), row.HinsyuCD.Trim());
                        }
                        //                          }
                        //                      }
                        break;

                    default:
                        addrow.Kingak = row.Seikyukin;
                        break;
                }

                //��.
                addrow.Kyoku = row.KyokuNM.Trim();
                //�ǃR�[�h.
                addrow.KyokuCd = row.KyokuCD.Trim();
                //�i�햼.
                if (!string.IsNullOrEmpty(row.HinsyuNM.Trim()))
                {
                    addrow.HinSyu = row.HinsyuNM.Trim();
                }
                //�i��R�[�h.
                addrow.HinSyuCd = row.HinsyuCD.Trim();
                //�㗝�X��("�d��"�ŌŒ�).
                addrow.DairiTen = "�d��";
                //�㗝�X�R�[�h.
                addrow.DairiTenCd = row.DairitenCD.Trim();
                //�ԑg�R�[�h.
                addrow.BangumiCd = row.BangumiCD.Trim();
                //����.
                addrow.KenMei = row.Kenmei.Trim();

                //�ԑg.
                RepDsAsh.BangumiDataRow[] BangumiTVDataRow = (RepDsAsh.BangumiDataRow[])AshDs.BangumiData.Select(" SYBT = '129'");
                RepDsAsh.BangumiDataRow[] BangumiRadioDataRow = (RepDsAsh.BangumiDataRow[])AshDs.BangumiData.Select("SYBT = '130'");
                switch (row.BaitaiCD.Trim())
                {

                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:  // 2015/06/08 K.F �V�L����ׁ@�A�T�q�Ή�.

                        foreach (RepDsAsh.BangumiDataRow bangumirow in BangumiTVDataRow)
                        {
                            if (bangumirow.BangumiCD.Trim().Equals(row.BangumiCD.Trim()))
                            {
                                addrow.Bangumi = bangumirow.BangumiNM.Trim();
                            }
                        }
                        break;


                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                        foreach (RepDsAsh.BangumiDataRow bangumiRaidorow in BangumiRadioDataRow)
                        {
                            if (bangumiRaidorow.BangumiCD.Trim().Equals(row.BangumiCD.Trim()))
                            {
                                addrow.Bangumi = bangumiRaidorow.BangumiNM.Trim();
                            }
                        }
                        break;

                    case KkhConstAsh.BaitaiCd.TV_SPOT:
                    case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                        addrow.Bangumi = "�X�|�b�g";

                        break;

                    default:
                        addrow.Bangumi = BaitaiCdForBaitaiNm(row.BaitaiCD.Trim());
                        break;
                }

                //���v�p�ɒl�����Z.
                SyoukeiKingak = SyoukeiKingak + double.Parse(row.Seikyukin.Trim());
                //���v�p�ɒl�����Z.
                SumKingaku = SumKingaku + double.Parse(row.Seikyukin.Trim());


                AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(addrow);
                XmlDs.displayKoukokuHi.ImportRow(addrow);

                //count++;
                BaitaiCount++;
            }
            //�Ō�̏��v �}��.
            RepDsAsh.displayKoukokuHiRow FinalSyoukeiRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
            FinalSyoukeiRow = RowSyokika(FinalSyoukeiRow);
            FinalSyoukeiRow.SeiKyuNumber = "�f�[�^�����v";
            FinalSyoukeiRow.Baitai = BaitaiCount.ToString();
            FinalSyoukeiRow.BaitaiCd = "���v";
            FinalSyoukeiRow.Kingak = SyoukeiKingak.ToString();
            AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(FinalSyoukeiRow);
            //�ŏI�s�@���v�@�}��.
            RepDsAsh.displayKoukokuHiRow FinalSumRow = AshDs.displayKoukokuHi.NewdisplayKoukokuHiRow();
            FinalSumRow = RowSyokika(FinalSumRow);
            FinalSumRow.SeiKyuNumber = "�f�[�^�����v";
            FinalSumRow.Baitai = count.ToString();
            FinalSumRow.BaitaiCd = "���v";
            FinalSumRow.Kingak = SumKingaku.ToString();

            //���̑��p�Ƀf�[�^��ێ��i�}�N���Ŏg�p����j.
            goukeikingak = SumKingaku.ToString();
            Datagoukei = count.ToString();

            AshDs.displayKoukokuHi.AdddisplayKoukokuHiRow(FinalSumRow);

            //Xml�p�ɔ}�̒P�ʂŏ��v���i�[.
            RepDsAsh.allbaitaiRow XmlFinalSyoukei = XmlDs.allbaitai.NewallbaitaiRow();
            XmlFinalSyoukei.baitaicd = beforeBaitaiCd;
            XmlFinalSyoukei.zeinasi = string.Empty;
            XmlFinalSyoukei.goukei = SyoukeiKingak.ToString();
            XmlDs.allbaitai.AddallbaitaiRow(XmlFinalSyoukei);
            //Xml�p�ɍ��v���i�[.
            RepDsAsh.allbaitaiRow XmlFinalSum = XmlDs.allbaitai.NewallbaitaiRow();
            XmlFinalSum.baitaicd = KkhConstAsh.BaitaiCd.ALL_BAITAI;
            XmlFinalSum.zeinasi = string.Empty;
            XmlFinalSum.goukei = SumKingaku.ToString();
            XmlDs.allbaitai.AddallbaitaiRow(XmlFinalSum);

            //�J���}��t���Ă���.
            for (int i = 0; i < AshDs.displayKoukokuHi.Rows.Count; i++)
            {
                double kanma = 0;
                //���z.
                if (!string.IsNullOrEmpty(AshDs.displayKoukokuHi[i].Kingak))
                {
                    kanma = double.Parse(AshDs.displayKoukokuHi[i].Kingak);
                    AshDs.displayKoukokuHi[i].Kingak = kanma.ToString("#,0");
                }
            }
            koukokuMain_Sheet1.DataSource = AshDs.displayKoukokuHi;
            btnXls.Enabled = true;

            //HorizontalAlignment����.
            for (int i = 0; i < koukokuMain_Sheet1.RowCount; i++)
            {
                if (koukokuMain_Sheet1.Cells[i, 1].Text == "�f�[�^�����v"
                    || koukokuMain_Sheet1.Cells[i, 1].Text == "�f�[�^�����v")
                {
                    koukokuMain_Sheet1.Cells[i, 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                }
            }

            //2015/02/23 miyanoue �V�L����ׁ@�A�T�q�Ή��@Start
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //���}�̃R�[�h����V�}�̖��́A�V�}�̃R�[�h���擾����.
            for (int i = 0; i < AshDs.displayKoukokuHi.Rows.Count; i++)
            {
                String baitaiCd = AshDs.displayKoukokuHi[i].BaitaiCd;

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(baitaiCd);

                AshDs.displayKoukokuHi[i].tokuisakiBaitaiCd = res.baitaiCd;
                AshDs.displayKoukokuHi[i].tokuisakiBaitai = res.baitaiNm;
            }

            for (int i = 0; i < XmlDs.displayKoukokuHi.Rows.Count; i++)
            {
                String baitaiCd = XmlDs.displayKoukokuHi[i].BaitaiCd;

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(baitaiCd);

                XmlDs.displayKoukokuHi[i].tokuisakiBaitaiCd = res.baitaiCd;
                XmlDs.displayKoukokuHi[i].tokuisakiBaitai = res.baitaiNm;
            }
            //2015/02/23 miyanoue �V�L����ׁ@�A�T�q�Ή��@End


            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();

            //�������ԍ��܂ł��Œ��ɂ���.
            koukokuMain_Sheet1.FrozenColumnCount = 2;
        }

        /// <summary>
        /// �R���{�{�b�N�X�����l�ݒ�.
        /// </summary>
        private void CombSet()
        {
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(string));
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.TV_TIME, KkhConstAsh.BaitaiCd.TV_TIME);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.TV_SPOT, KkhConstAsh.BaitaiCd.TV_SPOT);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.RADIO_TIME, KkhConstAsh.BaitaiCd.RADIO_TIME);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.RADIO_SPOT, KkhConstAsh.BaitaiCd.RADIO_SPOT);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SHINBUN, KkhConstAsh.BaitaiCd.SHINBUN);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ZASHI, KkhConstAsh.BaitaiCd.ZASHI);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.KOUTSU, KkhConstAsh.BaitaiCd.KOUTSU);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SEISAKU, KkhConstAsh.BaitaiCd.SEISAKU);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.EVENT, KkhConstAsh.BaitaiCd.EVENT);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.NEW_MEDIA, KkhConstAsh.BaitaiCd.NEW_MEDIA);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.INTERNET, KkhConstAsh.BaitaiCd.INTERNET);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.BS, KkhConstAsh.BaitaiCd.BS);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.CS, KkhConstAsh.BaitaiCd.CS);
            ////SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU, KkhConstAsh.BaitaiCd.OKUGAI);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.TYOUSA, KkhConstAsh.BaitaiCd.TYOUSA);
            ////2013/02/22 jse okazaki PR�}�̒ǉ��Ή��@Start
            ////���Ӑ悪�A�T�q�r�[���̏ꍇ.
            //if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
            //{
            //    SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.PR, KkhConstAsh.BaitaiCd.PR);
            //}
            ////2013/02/22 jse okazaki PR�}�̒ǉ��Ή��@End
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SONOTA, KkhConstAsh.BaitaiCd.SONOTA);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.MEDIA_FEE, KkhConstAsh.BaitaiCd.MEDIA_FEE);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.BRAND_FEE, KkhConstAsh.BaitaiCd.BRAND_FEE);
            //SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ALL_BAITAI, KkhConstAsh.BaitaiCd.ALL_BAITAI);

            //2015/02/23 miyanoue �V�L����ׁ@�A�T�q�Ή��@Start
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //���}�̖��̂���V�}�̖��̂֕ϊ�����.

            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();

            //�R���{�{�b�N�X�̐���.
            for (int i = 0; i < resultList.Count; i++)
            {
                SybtNameTable.Rows.Add(resultList[i].baitaiNm, resultList[i].baitaiCd);
            }
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ALL_BAITAI, KkhConstAsh.BaitaiCd.ALL_BAITAI);

            mediaCmb.DataSource = SybtNameTable;
            mediaCmb.DisplayMember = "Display";
            mediaCmb.ValueMember = "Value";
            mediaCmb.SelectedValue = KkhConstAsh.BaitaiCd.ALL_BAITAI;
        }

        /// <summary>
        /// �}�̃R�[�h����}�̖�.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string BaitaiCdForBaitaiNm(string baitaiCd)
        {
            //�}�̖�.
            string baitaiNm = string.Empty;

            switch (baitaiCd)
            {
                case KkhConstAsh.BaitaiCd.TV_TIME:
                    baitaiNm = KkhConstAsh.BaitaiNm.TV_TIME;
                    break;
                case KkhConstAsh.BaitaiCd.TV_SPOT:
                    baitaiNm = KkhConstAsh.BaitaiNm.TV_SPOT;
                    break;
                case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    baitaiNm = KkhConstAsh.BaitaiNm.RADIO_TIME;
                    break;
                case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                    baitaiNm = KkhConstAsh.BaitaiNm.RADIO_SPOT;
                    break;
                case KkhConstAsh.BaitaiCd.SHINBUN:
                    baitaiNm = KkhConstAsh.BaitaiNm.SHINBUN;
                    break;
                case KkhConstAsh.BaitaiCd.ZASHI:
                    baitaiNm = KkhConstAsh.BaitaiNm.ZASHI;
                    break;
                case KkhConstAsh.BaitaiCd.KOUTSU:
                    baitaiNm = KkhConstAsh.BaitaiNm.KOUTSU;
                    break;
                case KkhConstAsh.BaitaiCd.OKUGAI:
                    baitaiNm = KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU;
                    break;
                case KkhConstAsh.BaitaiCd.SEISAKU:
                    baitaiNm = KkhConstAsh.BaitaiNm.SEISAKU;
                    break;
                case KkhConstAsh.BaitaiCd.EVENT:
                    baitaiNm = KkhConstAsh.BaitaiNm.EVENT;
                    break;
                //2013/02/22 jse okazaki PR�}�̒ǉ��Ή��@Start
                case KkhConstAsh.BaitaiCd.PR:
                    baitaiNm = KkhConstAsh.BaitaiNm.PR;
                    break;
                //2013/02/22 jse okazaki PR�}�̒ǉ��Ή��@End
                case KkhConstAsh.BaitaiCd.SONOTA:
                    baitaiNm = KkhConstAsh.BaitaiNm.SONOTA;
                    break;
                case KkhConstAsh.BaitaiCd.NEW_MEDIA:
                    baitaiNm = KkhConstAsh.BaitaiNm.NEW_MEDIA;
                    break;
                case KkhConstAsh.BaitaiCd.INTERNET:
                    baitaiNm = KkhConstAsh.BaitaiNm.INTERNET;
                    break;
                case KkhConstAsh.BaitaiCd.BS:
                    baitaiNm = KkhConstAsh.BaitaiNm.BS;
                    break;
                case KkhConstAsh.BaitaiCd.CS:
                    baitaiNm = KkhConstAsh.BaitaiNm.CS;
                    break;
                case KkhConstAsh.BaitaiCd.TYOUSA:
                    baitaiNm = KkhConstAsh.BaitaiNm.TYOUSA;
                    break;
                case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    baitaiNm = KkhConstAsh.BaitaiNm.MEDIA_FEE;
                    break;
                case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    baitaiNm = KkhConstAsh.BaitaiNm.BRAND_FEE;
                    break;
            }
            return baitaiNm;
        }

        /// <summary>
        /// �}�X�^���̎擾.
        /// </summary>
        private void MstDataGet()
        {
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            ReportAshProcessController processcontroller = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processcontroller.findReportMediaCode(param);
            if (result.HasError)
            {
                return;
            }
            //          if (result.dsAshDataSet.OldKyokuCd.Rows.Count == 0)
            //          {
            //             // MessageBox.Show("�}�X�^�f�[�^������܂���B�V�X�e���Ǘ��҂ɘA�����ĉ������B");
            //              MessageUtility.ShowMessageBox(MessageCode.HB_E0012, null, "�}�X�^���擾", MessageBoxButtons.OK);
            //              return;
            //          }
            AshDs.Merge(result.dsAshDataSet);
        }

        /// <summary>
        /// �������z�̕\���A��\��.
        /// </summary>
        /// <param name="JyutNo"></param>
        /// <param name="JyMeiNo"></param>
        /// <param name="UriMeiNo"></param>
        /// <param name="HinSyuCd"></param>
        /// <returns></returns>
        private string SeiGakVisible(string JyutNo, string JyMeiNo, string UriMeiNo, string HinSyuCd)
        {
            RepDsAsh.TvRadioTimeKingakRow[] KingakRow = (RepDsAsh.TvRadioTimeKingakRow[])AshDs.TvRadioTimeKingak.Select("", "");
            foreach (RepDsAsh.TvRadioTimeKingakRow row in KingakRow)
            {
                //�󒍂m���A�󒍖��ׂm���A���㖾�ׂm���A�i��R�[�h����v����ꍇ.
                if (JyutNo.Equals(row.JyutNo.Trim()) && JyMeiNo.Equals(row.JyMeiNo.Trim())
                   && UriMeiNo.Equals(row.UrMeiNo.Trim()) && HinSyuCd.Equals(row.HinsyuCD.Trim()))
                {
                    return row.SeiGak.Trim();
                }
            }
            return "0";
        }

        /// <summary>
        /// �s�f�[�^�̏�����.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.displayKoukokuHiRow RowSyokika(RepDsAsh.displayKoukokuHiRow addrow)
        {

            addrow.No = string.Empty;
            addrow.SeiKyuNumber = string.Empty;
            addrow.Baitai = string.Empty;
            addrow.BaitaiCd = string.Empty;
            addrow.Kingak = string.Empty;
            addrow.Kyoku = string.Empty;
            addrow.KyokuCd = string.Empty;
            addrow.HinSyu = string.Empty;
            addrow.HinSyuCd = string.Empty;
            addrow.DairiTen = string.Empty;
            addrow.DairiTenCd = string.Empty;
            addrow.Bangumi = string.Empty;
            addrow.BangumiCd = string.Empty;
            addrow.KenMei = string.Empty;

            return addrow;

        }

        /// <summary>
        /// Excel�쐬�p�f�[�^�i�[.
        /// </summary>
        private void excelDataSet()
        {
            delDs.Clear();
            delDs.Merge(XmlDs);

            string selectBaitai = String.Empty;
            string selectBaitaiText = String.Empty;

            //2015/03/31 miyanoue �A�T�q�Ή� Stret
            //if (mediaCmb.SelectedValue.Equals(KkhConstAsh.BaitaiCd.EVENT))
            //{
            //    selectBaitai = KkhConstAsh.BaitaiCd.OKUGAI + "','" + KkhConstAsh.BaitaiCd.EVENT;
            //}
            //else
            //{
            //    selectBaitai = mediaCmb.SelectedValue.ToString();
            //    selectBaitaiText = mediaCmb.Text.ToString();
            //}

            if (mediaCmb.SelectedValue.Equals(KkhConstAsh.BaitaiCd.EVENT))
            {
                selectBaitai = KkhConstAsh.BaitaiCd.OKUGAI + "','" + KkhConstAsh.BaitaiCd.EVENT;
                selectBaitaiText = mediaCmb.Text.ToString();
            }
            else
            {
                selectBaitai = mediaCmb.SelectedValue.ToString();
                selectBaitaiText = mediaCmb.Text.ToString();
            }


            //2015/03/31 miyanoue �A�T�q�Ή� End

            //�S�}�̂̏ꍇ.
            if ((mediaCmb.SelectedValue == null) || (mediaCmb.SelectedValue.ToString().Equals(KkhConstAsh.BaitaiCd.ALL_BAITAI)))
            {

            }
            else
            {
                /* 2014/10/09 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD start */
                //RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])
                //RepDsAsh.displayKoukokuHiRow[] CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" BaitaiCd IN ('" + selectBaitai + "') ");

                RepDsAsh.displayKoukokuHiRow[] CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select();

                //���Ӑ悪�A�T�q�r�[���̏ꍇ.
                if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                {
                    //�}�̖��̂Ō���.
                    //2015/03/31 miyanoue �A�T�q�Ή� Start
                    //CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select("Baitai = '" + selectBaitaiText + "'");
                    CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select("tokuisakiBaitai = '" + selectBaitaiText + "'");
                    //2015/03/31 miyanoue �A�T�q�Ή� End
                }
                //���Ӑ悪�A�T�q�����̏ꍇ.
                else
                {
                    CheckRow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select("BaitaiCd IN ('" + selectBaitai + "')");
                }
                /* 2014/10/09 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD end */

                //�I�����ꂽ�}�̂������ꍇ.
                if (CheckRow.Length == 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0038, null, "���[", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    /* 2014/10/09 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD start */
                    //RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                    //foreach (RepDsAsh.displayKoukokuHiRow del in delrow)
                    //{
                    //    delDs.displayKoukokuHi.Rows.Remove(del);
                    //}
                    //RepDsAsh.allbaitaiRow[] delAllRow = (RepDsAsh.allbaitaiRow[])delDs.allbaitai.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                    //foreach (RepDsAsh.allbaitaiRow delall in delAllRow)
                    //{
                    //    delDs.allbaitai.Rows.Remove(delall);
                    //}

                    //���Ӑ悪�A�T�q�r�[���̏ꍇ.
                    if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                    {
                        //2015/03/31 miyanoue �A�T�q�Ή� Start
                        //RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" Baitai NOT IN ('" + selectBaitaiText + "') ");
                        RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" tokuisakiBaitai NOT IN ('" + selectBaitaiText + "') ");
                        //2015/03/31 miyanoue �A�T�q�Ή� End
                        foreach (RepDsAsh.displayKoukokuHiRow del in delrow)
                        {
                            delDs.displayKoukokuHi.Rows.Remove(del);
                        }
                        RepDsAsh.allbaitaiRow[] delAllRow = (RepDsAsh.allbaitaiRow[])delDs.allbaitai.Select("BaitaiCd NOT IN ('" + selectBaitai + "') ");
                        foreach (RepDsAsh.allbaitaiRow delall in delAllRow)
                        {
                            delDs.allbaitai.Rows.Remove(delall);
                        }
                    }
                    //���Ӑ悪�A�T�q�����̏ꍇ.
                    else
                    {
                        RepDsAsh.displayKoukokuHiRow[] delrow = (RepDsAsh.displayKoukokuHiRow[])delDs.displayKoukokuHi.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                        foreach (RepDsAsh.displayKoukokuHiRow del in delrow)
                        {
                            delDs.displayKoukokuHi.Rows.Remove(del);
                        }
                        RepDsAsh.allbaitaiRow[] delAllRow = (RepDsAsh.allbaitaiRow[])delDs.allbaitai.Select(" BaitaiCd NOT IN ('" + selectBaitai + "') ");
                        foreach (RepDsAsh.allbaitaiRow delall in delAllRow)
                        {
                            delDs.allbaitai.Rows.Remove(delall);
                        }
                    }
                    /* 2014/10/09 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD end */
                }
            }
            //2015/02/23 miyanoue �V�L����ׁ@�A�T�q�Ή��@Start
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //���}�̃R�[�h����V�}�̖��́A�V�}�̃R�[�h���擾����.
            for (int i = 0; i < delDs.displayKoukokuHi.Rows.Count; i++)
            {
                String baitaiCd = delDs.displayKoukokuHi[i].BaitaiCd;

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(baitaiCd);

                delDs.displayKoukokuHi[i].tokuisakiBaitaiCd = res.baitaiCd;
                delDs.displayKoukokuHi[i].tokuisakiBaitai = res.baitaiNm;
            }
            //2015/02/23 miyanoue �V�L����ׁ@�A�T�q�Ή��@End

            //�G�N�Z���o�̓t�@�C���̐ݒ�.
            excelFileSet();
        }

        /// <summary>
        /// �G�N�Z���o�͂̃t�@�C���ݒ�.
        /// </summary>
        private void excelFileSet()
        {
            //�t�@�C���ۑ��ꏊ�ݒ�N���X�̃C���X�^���X��.
            SaveFileDialog sfd = new SaveFileDialog();
            //���ݓ���.
            DateTime nowdate = DateTime.Now;
            //�����t�@�C����.
            sfd.FileName = pStrRepFilNam + "_" + nowdate.ToString("yyyyMMdd") + ".xlsx";
            //sfd.FileName = nowdate.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
            //�����t�@�C���ۑ���.
            sfd.InitialDirectory = pStrRepAdrs;
            //�t�@�C����ނ̑I������ݒ�.
            sfd.Filter = "XLSX�t�@�C��(*.xlsx)|*.xlsx";
            //�����t�@�C����ނ̐ݒ�.
            //[���ׂẴt�@�C��]��ݒ�.
            sfd.FilterIndex = 0;
            //�^�C�g���̐ݒ�.
            sfd.Title = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";
            //�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���.
            sfd.RestoreDirectory = true;
            //�_�C�A���O��\�����AOk�{�^�����������ꂽ��.

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��邩�`�F�b�N.
                try
                {
                    //�����Ńt�@�C�����폜����B.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��܂��B���Ă���ēx�o�͂��Ă��������B.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "���[", MessageBoxButtons.OK);
                    return;
                }

                //*************************************
                // �o�͎��s.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }

        }

        /// <summary>
        /// �G�N�Z���o��.
        /// </summary>
        /// <param name="filenm"></param>
        private void ExcelOut(string filenm)
        {
            //��Ɨp�t�H���_�p�X.
            string workFolderPath = pStrRepTempAdrs;
            string macrofile = workFolderPath + REP_MACRO_FILENAME;
            string tempfile = workFolderPath + REP_TEMPLATE_FILENAME;
            //�e�[�u���ǉ��p�f�[�^Row.
            DataRow dtRow;

            try
            {
                // Excel�J�n����.
                // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_KoukokuHi);
                File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_KoukokuHi_Template);

                if (System.IO.File.Exists(tempfile) == false) { throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B"); }
                if (System.IO.File.Exists(macrofile) == false) { throw new Exception("�}�N��Excel�t�@�C��������܂���B"); }


                //�f�[�^�Z�b�gXML�o��.
                delDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                //MacLicenseeDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                // �p�����[�^XML�쐬�A�o��.
                // �ϐ��̐錾.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // �f�[�^�Z�b�g�Ƀe�[�u����ǉ�����.
                // PRODUCTS�Ƃ����e�[�u�����쐬���܂�.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));
                dtTable.Columns.Add("BAITAICD", Type.GetType("System.String"));
                dtTable.Columns.Add("DATAGOUKEI", Type.GetType("System.String"));
                dtTable.Columns.Add("GOUKEIKINGAK", Type.GetType("System.String"));

                //�e�[�u���Ƀf�[�^��ǉ�����.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = dtpYyyyMmDd.Value.ToString("yyyyMMdd");
                //dtRow["SELHDK"] = txtYyyy.Value.ToString() + "/" + txtMm.Value.ToString() + "/" + txtDay.Text.ToString();
                //dtRow["SELHDK"] = YymmDdSet();

                if (mediaCmb.SelectedValue != null)
                {
                    dtRow["BAITAICD"] = mediaCmb.SelectedValue.ToString();
                    //�I�����ꂽ�̂����̑��̏ꍇ.
                    if (mediaCmb.SelectedValue.ToString().Equals(KkhConstAsh.BaitaiCd.SONOTA))
                    {
                        dtRow["DATAGOUKEI"] = Datagoukei;
                        dtRow["GOUKEIKINGAK"] = goukeikingak;
                    }
                }
                else
                {
                    dtRow["BAITAICD"] = BLANK_SELECTED_VALUE;
                }

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //�G�N�Z���N��.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // �I�y���[�V�������O�̏o��.
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_Koukokuhi, KKHLogUtilityAsh.DESC_OPERATION_LOG_Koukokuhi);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion ���\�b�h.
    }

}

