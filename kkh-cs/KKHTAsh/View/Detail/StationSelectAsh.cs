using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Ash.Utility;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.ProcessController.Detail;
using KKHUserManual.Helper;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// �ǑI��.
    /// </summary>
    public partial class StationSelectAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region �萔.
        #region ���i��.
        /// <summary>
        /// ���i��.
        /// </summary>
        public const int COLIDX_KLIST_SHOUHINCD_CNT = 10;
        #endregion ���i��.

        #region �ǑI���ꗗ��C���f�b�N�X.
        /// <summary>
        /// �ǃR�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_KLIST_KYOKUCD = 0;
        /// <summary>
        /// ���i��(�擪)�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_KLIST_SHOUHINCD_FIRST = 1;
        /// <summary>
        /// ���i��(�ŏI)�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_KLIST_SHOUHINCD_END = 10;
        #endregion �ǑI���ꗗ��C���f�b�N�X.

        #region �ǑI���ꗗ�s�C���f�b�N�X.
        /// <summary>
        /// ���i�R�[�h�s�C���f�b�N�X.
        /// </summary>
        public const int ROWIDX_KLIST_SHOUHINCD = 0;
        /// <summary>   
        /// �z�����s�C���f�b�N�X.
        /// </summary>
        public const int ROWIDX_KLIST_HAIBUNRITU = 1;
        /// <summary>
        /// �[���敪�s�C���f�b�N�X.
        /// </summary>
        public const int ROWIDX_KLIST_HASUKBN = 2;
        /// <summary>
        /// �ǃR�[�h�s(�擪)�C���f�b�N�X.
        /// </summary>
        public const int ROWIDX_KLIST_KYOKUCD_FIRST = 3;
        #endregion �ǑI���ꗗ�s�C���f�b�N�X.
        #endregion �萔.

        #region �����o�ϐ�.
        /// <summary>
        /// �󒍃f�[�^.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        /// <summary>
        /// ���ד��̓V�[�g.
        /// </summary>
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// ���i���(�L�[). 
        /// </summary>
        private string[] _itemShouhinCd = null;
        /// <summary>
        /// ���i���(����).
        /// </summary>
        private string[] _itemShouhinNm = null;
        /// <summary>
        /// ���i���f�[�^�Z�b�g.
        /// </summary>
        private MasterMaintenance _dsShouhinInfo = null;
        /// <summary>
        /// �Ǐ��(�L�[).
        /// </summary>
        private string[] _itemKyokuCd = null;
        /// <summary>
        /// �Ǐ��(����).
        /// </summary>
        private string[] _itemKyokuNm = null;
        /// <summary>
        /// �Ǐ��f�[�^�Z�b�g.
        /// </summary>
        private MasterMaintenance _dsKyokuInfo = null;
        /// <summary>
        /// �[���敪(�L�[).
        /// </summary>
        private string[] _itemHasuKbnCd = null;
        /// <summary>
        /// �[���敪(����).
        /// </summary>
        private string[] _itemHasuKbnNm = null;
        /// <summary>
        /// ���i�R�[�h����.
        /// </summary>
        private int _shouhinCdCnt = 0;
        /// <summary>
        /// �z��������.
        /// </summary>
        private decimal _bunbo = 0;
        /// <summary>
        /// �z����(�z��).
        /// </summary>
        private decimal[] _haibunrituArray;
        /// <summary>
        /// �[���敪(�z��).
        /// </summary>
        private String[] _hasuKbn;
        /// <summary>
        /// �`�F�b�N�{�b�N�X�ݒ�l(�z��)�������l�͐ݒ�Ȃ�.
        /// </summary>
        private bool[] _checkBoxValue = new bool[COLIDX_KLIST_SHOUHINCD_CNT];
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public StationSelectAsh()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^.

        #region �C�x���g.
        #region OK�{�^���N���b�N�C�x���g.
        /// <summary>
        /// OK�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //���̓`�F�b�N.
            if (!checkInput())
            {
                return;
            }

            //���ד��͉�ʕҏW.
            editDetailInput();

            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }
        #endregion OK�{�^���N���b�N�C�x���g.

        #region �L�����Z���{�^���N���b�N�C�x���g.
        /// <summary>
        /// �L�����Z���{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }
        #endregion �L�����Z���{�^���N���b�N�C�x���g.

        #region �폜�{�^���N���b�N�C�x���g.
        /// <summary>
        /// �폜�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //�����ݒ�.
            int rowIndex = spdKyokuSentakuList_Sheet1.ActiveRowIndex;

            //�I���s���[���敪�s�C���f�b�N�X�����傫���ꍇ.
            if (rowIndex > ROWIDX_KLIST_HASUKBN)
            {
                //�w�肵���s�̍폜.
                spdKyokuSentakuList_Sheet1.RemoveRows(rowIndex, 1);
            }

            //�t�H�[�J�X�ݒ�.
            spdKyokuSentakuList.Focus();
        }
        #endregion �폜�{�^���N���b�N�C�x���g.

        #region �s�}���{�^���N���b�N�C�x���g.
        /// <summary>
        /// �s�}���{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //�ŏI�s�ɒǉ�.
            int activeRowIndex = spdKyokuSentakuList_Sheet1.ActiveRowIndex;
            spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);

            //�ǃR�[�h�R���{�{�b�N�X.
            setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);

            //�w�b�_�[�s�̏ꍇ.
            if (activeRowIndex < ROWIDX_KLIST_KYOKUCD_FIRST)
            {
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value = "";
            }
            //�ǃR�[�h�\���s�̏ꍇ.
            else
            {
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value = spdKyokuSentakuList_Sheet1.Cells[activeRowIndex, COLIDX_KLIST_KYOKUCD].Value.ToString().Trim();
            }

            //���i(�擪�s)�C���f�b�N�X���珤�i(�ŏI�s)�C���f�b�N�X�܂Ń��[�v����.
            for (int i = COLIDX_KLIST_SHOUHINCD_FIRST; i <= COLIDX_KLIST_SHOUHINCD_END; i++)
            {
                //�`�F�b�N�{�b�N�X.
                setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, i);
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, i].Value = true;
            }

            //�t�H�[�J�X�ݒ�.
            spdKyokuSentakuList.Focus();
        }
        #endregion �s�}���{�^���N���b�N�C�x���g.

        #region �X�v���b�h�_�u���N���b�N�C�x���g.
        /// <summary>
        /// �X�v���b�h�_�u���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKyokuSentakuList_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            //�w�b�_�[�̏ꍇ.
            if (e.ColumnHeader)
            {
                //���i�R�[�h��̏ꍇ.
                if (e.Column >= COLIDX_KLIST_SHOUHINCD_FIRST)
                {
                    //�ǃR�[�h�̌������A�J��Ԃ�.
                    for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                    {
                        //�`�F�b�N�{�b�N�X�̐ݒ�.
                        spdKyokuSentakuList_Sheet1.Cells[rowIndex, e.Column].Value = _checkBoxValue[e.Column - 1];
                    }

                    //����p�Ƀ`�F�b�N�{�b�N�X�̒l���X�V.
                    _checkBoxValue[e.Column - 1] = !(_checkBoxValue[e.Column - 1]);
                }
            }
        }
        #endregion �X�v���b�h�_�u���N���b�N�C�x���g.

        #region �t�H�[�����[�h�C�x���g.
        /// <summary>
        /// �t�H�[�����[�h�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StationSelectAsh_Load(object sender, EventArgs e)
        {
            //�e�R���g���[���̕ҏW.
            editControl();
        }
        #endregion �t�H�[�����[�h�C�x���g.

        #region �i�r�p�����[�^�[���̐ݒ�.
        /// <summary>
        /// �i�r�p�����[�^�[���̐ݒ�.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void StationSelectAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //�i�r�p�������݂��Ȃ��ꍇ.
            if (arg.NaviParameter == null)
            {
                return;
            }

            //�i�r�p�����̐ݒ�.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
                _dataRow = _naviParam.DataRow;
                _spdDetailInput_Sheet1 = _naviParam.SpdDetailInput_Sheet1;
            }
        }
        #endregion �i�r�p�����[�^�[���̐ݒ�.
        #endregion �C�x���g.

        #region ���\�b�h.
        #region �e�R���g���[���̕ҏW����.
        /// <summary>
        /// �e�R���g���[���̕ҏW����.
        /// </summary>
        private void editControl()
        {
            //�}�̃R�[�h���e���r�^�C���̏ꍇ.
            if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd) == true
                /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD Start */
                || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) == true)
                /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD End */
            {
                //�e���r�ǃ}�X�^�擾.
                setKyokuInfo(Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.TV_KYOKU);
            }
            //�}�̃R�[�h����L�ȊO�̏ꍇ.
            else
            {
                //���W�I�ǃ}�X�^�擾.
                setKyokuInfo(Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.RADIO_KYOKU);
            }

            //���i�}�X�^�擾.
            setShouhinInfo();

            //�[���敪.
            setHasuKbn();

            //�i��R�[�h�񐔕��A�J��Ԃ�.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
            {
                //���i�R�[�h�R���{�{�b�N�X�쐬.
                setComboBox(ROWIDX_KLIST_SHOUHINCD, colIndex, _itemShouhinCd, _itemShouhinNm);

                //�[���敪�R���{�{�b�N�X�쐬.
                setComboBox(ROWIDX_KLIST_HASUKBN, colIndex, _itemHasuKbnCd, _itemHasuKbnNm);
            }

            //���ϋ��z���v.
            decimal hnmaeGakGoukei = 0;
            /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
            //string firstKyokuCd = _spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
            string firstKyokuCd = string.Empty;

            //�ǃR�[�h����łȂ��ꍇ.
            if (_spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_KYOKUCD].Value != null)
            {
                //����1�s�ڂɋǃR�[�h��ݒ�.
                firstKyokuCd = _spdDetailInput_Sheet1.Cells[0, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
            }
            /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */

            //�ǃR�[�h�̌������A�J��Ԃ�(���X�g�̐擪�͋󔒂Ȃ̂őΏۊO�Ȃ̂ŁA�Q���R�[�h�ڂ��炪�Ώ�).
            for (int i = 1; i < _itemKyokuCd.Length; i++)
            {
                //�e���r�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ���A�ǃR�[�h�̐擪1��������v���Ȃ��ꍇ�͕\�����Ȃ�.
                if (KkhConstAsh.BaitaiCd.TV_TIME == _naviParam.BaitaiCd
                    /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD Start */
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT == _naviParam.BaitaiCd)
                    /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD End */
                {
                    //�ǃR�[�h�ɒl������ꍇ.
                    if (!string.IsNullOrEmpty(firstKyokuCd))
                    {
                        //����1�Ɩ��̋ǃR�[�h���Ǐ��(�L�[)�ɑ��݂��Ȃ��ꍇ.
                        if (firstKyokuCd.Substring(0, 1) != _itemKyokuCd[i].Trim().Substring(0, 1))
                        {
                            continue;
                        }
                    }
                }

                //1�s�ǉ�����.
                spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);

                //�ǃR�[�h�R���{�{�b�N�X�쐬.
                setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);

                //�ǃR�[�h�R���{�{�b�N�X�����l�ݒ�.
                spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value = _itemKyokuCd[i].Trim();

                //�i��R�[�h�񐔕��A�J��Ԃ�.
                for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                {
                    //�`�F�b�N�{�b�N�X����.
                    setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                }
            }

            /* 2013/01/29 JSE A.Naito MOD Start*/
            //���ד��͉�ʂ̍s�����̏��i�R�[�h���i�[�ł���z��.
            String[] aryKyokuCd = new String[_spdDetailInput_Sheet1.RowCount];
            aryKyokuCd[0] = firstKyokuCd;
            int countKyokuCd = 1;
            bool flg = true;
            /* 2013/01/29 JSE A.Naito MOD End*/

            //���ד��͂̌������A�J��Ԃ�.
            for (int detailInputRowIndex = 0; detailInputRowIndex < _spdDetailInput_Sheet1.RowCount; detailInputRowIndex++)
            {
                //�e���r�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ���A�ǃR�[�h�̐擪1��������v���Ȃ��ꍇ�͕\�����Ȃ�.
                if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd) == true
                    /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD Start */
                    || KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd) == true)
                    /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD End */
                {
                    //�ǃR�[�h�ɒl������ꍇ.
                    if (!string.IsNullOrEmpty(firstKyokuCd))
                    {
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
                        /* 2013/01/29 JSE A.Naito MOD Start */
                        //if (firstKyokuCd.Substring(0, 1) != _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim().Substring(0, 1))
                        //{
                        //    //�z��̗v�f�����J��Ԃ�.
                        //    for (int i = 0; i < countKyokuCd; i++)
                        //    {
                        //        if (aryKyokuCd[i].Equals(_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim()))
                        //        {
                        //            flg = false;
                        //            break;
                        //        }
                        //    }
                        //    if (flg)
                        //    {
                        //        //1�s�ǉ�����.
                        //        spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);
                        //        //�ǃR�[�h�R���{�{�b�N�X�쐬.
                        //        setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);
                        //        //�ǃR�[�h�R���{�{�b�N�X�����l�ݒ�.
                        //        spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value
                        //            = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                        //        //�`�F�b�N�{�b�N�X����.
                        //        for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                        //        {
                        //            setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                        //        }
                        //        //�z��̍Ō�ɋǃR�[�h��ǉ�.
                        //        aryKyokuCd[countKyokuCd] = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                        //        countKyokuCd += 1;
                        //    }
                        //}
                        /* 2013/01/29 JSE A.Naito MOD End */
                        ////if (firstKyokuCd.Substring(0, 1) !=_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim().Substring(0, 1))
                        ////{
                        ////    //1�s�ǉ�����.
                        ////    spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);
                        ////    //�ǃR�[�h�R���{�{�b�N�X�쐬.
                        ////    setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);
                        ////    //�ǃR�[�h�R���{�{�b�N�X�����l�ݒ�.
                        ////    spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value
                        ////        = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                        ////    //�`�F�b�N�{�b�N�X����.
                        ////    for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                        ////    {
                        ////        setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                        ////    }
                        ////}
                        //�ǃR�[�h�����݂���A2�����ȏ�̏ꍇ.
                        if ((_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value != null) && (_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Length >2))
                        {
                            //����1�s�ڂ̋ǃR�[�h�Ɩ��ד��̓V�[�g�̋ǃR�[�h���قȂ�ꍇ.
                            if (firstKyokuCd.Substring(0, 1) != _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim().Substring(0, 1))
                            {
                                //�z��̗v�f�����J��Ԃ�.
                                for (int i = 0; i < countKyokuCd; i++)
                                {
                                    //�ǃR�[�h������̏ꍇ.
                                    if (aryKyokuCd[i].Equals(_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim()))
                                    {
                                        flg = false;
                                        break;
                                    }
                                }
                                if (flg)
                                {
                                    //1�s�ǉ�����.
                                    spdKyokuSentakuList_Sheet1.AddRows(spdKyokuSentakuList_Sheet1.RowCount, 1);
                                    //�ǃR�[�h�R���{�{�b�N�X�쐬.
                                    setComboBox(spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD, _itemKyokuCd, _itemKyokuNm);
                                    //�ǃR�[�h�R���{�{�b�N�X�����l�ݒ�.
                                    spdKyokuSentakuList_Sheet1.Cells[spdKyokuSentakuList_Sheet1.RowCount - 1, COLIDX_KLIST_KYOKUCD].Value
                                        = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                                    //�`�F�b�N�{�b�N�X����.
                                    for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
                                    {
                                        setCheckBox(spdKyokuSentakuList_Sheet1.RowCount - 1, colIndex);
                                    }
                                    //�z��̍Ō�ɋǃR�[�h��ǉ�.
                                    aryKyokuCd[countKyokuCd] = _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim();
                                    countKyokuCd += 1;
                                }
                            }
                        }
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */
                    }
                }

                /* 2013/01/29 JSE A.Naito ADD Start */ 
                //�t���O��true�ɖ߂�.
                flg = true;

                //���z����̏ꍇ�́A"0"������.
                if (_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_HNMAEGAK].Text.Equals(""))
                {
                    _spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_HNMAEGAK].Text = "0"; 
                }
                /* 2013/01/29 JSE A.Naito ADD End */

                //���ϋ��z�̍��v�����Z.
                hnmaeGakGoukei += int.Parse(_spdDetailInput_Sheet1.Cells[detailInputRowIndex, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
            }

            //�����ݒ�.
            int shouhinColIndex = COLIDX_KLIST_SHOUHINCD_FIRST;
            decimal seiSoGokei = 0M;
            decimal seiShokei = 0M;
            int shohIdx = 1;
            int snziIdx = 0;
            bool bln = false;
            String hnshCd = String.Empty;
            //���ד��͉�ʂ̍s�����̏��i�R�[�h���i�[�ł���z��.
            String[] hnshCd2 = new String[_spdDetailInput_Sheet1.RowCount];

            //���ד��͉�ʂ̌��ϊz���v���Z�o����.
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                //���ϋ��z�̍��v�����Z.
                seiSoGokei += decimal.Parse(_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
            }

            //���ד��͉�ʂ̌�������������.
            for (int j = 0; j < _spdDetailInput_Sheet1.RowCount; j++)
            {
                bln = false;

                /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
                //���ד��͉�ʂ̏��i�R�[�h���擾.
                //hnshCd = _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                if (_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                {
                    hnshCd = _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */
                }else
                {
                    hnshCd = string.Empty;
                }

                //�����Ώۏ��i�R�[�h�����łɏ����ς݂��`�F�b�N.
                if (hnshCd2.Length > 0)
                {
                    for (int i = 0; i < hnshCd2.Length; i++)
                    {
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
                        //if (!String.IsNullOrEmpty(hnshCd2[i]))
                        //{
                        //    if (hnshCd2[i].Equals(hnshCd))
                        //    {
                        //        bln = true;
                        //    }
                        //}
                        if(hnshCd2[i] != null)
                        {
                            if (hnshCd2[i].Equals(hnshCd))
                            {
                                bln = true;
                            }
                        }
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */
                    }
                }

                //�����Ώەi��R�[�h.
                if (!bln && j < _spdDetailInput_Sheet1.RowCount)
                {
                    //���ד��͉�ʂ̌�������������.
                    for (int row = 0; row < _spdDetailInput_Sheet1.RowCount; row++)
                    {
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
                        //object val = _spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HINSYUCD].Value;
                        ////���ד��͉�ʂœ���̏��i�R�[�h������ꍇ.
                        //if (hnshCd == val.ToString().Trim())
                        //{
                        //    //�������z�����Z����.
                        //    seiShokei += decimal.Parse(_spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
                        //}

                        object val = "";
                        if (_spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                        {
                            val = _spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HINSYUCD].Value;
                        }
                        if (hnshCd == val.ToString().Trim())
                        {
                            //�������z�����Z����.
                            seiShokei += decimal.Parse(_spdDetailInput_Sheet1.Cells[row, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));
                        }
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */
                    }
                }

                //����.
                if (j == 0)
                {
                    //�i��R�[�h�����l�ݒ�.
                    spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, shohIdx].Value = hnshCd;

                    //���ד��́D�[��������"�؏グ"�̏ꍇ.
                    if (KkhConstAsh.HasuKbn.ROUNDUP.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                    {
                        //�z����.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                        //�[���敪.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                    }
                    //���ד��́D�[��������"�؎̂�"�̏ꍇ.
                    else if (KkhConstAsh.HasuKbn.ROUNDDOWN.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                    {
                        //�z����.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                        //�[���敪.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                    }
                    //��L�ȊO�̏ꍇ�A�z�������Z�o����.
                    else
                    {
                        //���ד��́D���ϋ��z�A���ד��́D���ϋ��z�̍��v��0�ȊO�̏ꍇ.
                        if (seiShokei != 0 && seiSoGokei != 0)
                        {
                            /*
                             * �z����.
                             * ���ϋ��z / ���ϋ��z�̍��v) * 100.
                             * ���������������傤�� 0.5 �̏ꍇ�A�ł��߂������ɒl���ۂ߂�.
                             * 0.5�� 0�A1.5 �� 2
                             */
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                        }
                    }
                }
                else if (j > 0)
                {
                    //�i�푶�݃t���O.
                    bool hnshFlg = false;
                    //���݃C���f�b�N�X.
                    snziIdx = 0;
                    for (int kCol = 1; kCol <= shohIdx; kCol++)
                    {
                        //���łɌn��V�[�g�ɓ���̕i��R�[�h�����łɂ���ꍇ.
                        if (hnshCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, kCol].Value))
                        {
                            hnshFlg = true;
                            snziIdx = kCol;
                        }
                    }

                    //�i�푶�݃t���O��true�̏ꍇ.
                    if (hnshFlg)
                    {
                        //�i��R�[�h�����l�ݒ�.
                        spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, snziIdx].Value = _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HINSYUCD].Value;

                        //���ד��́D�[��������"�؏グ"�̏ꍇ.
                        if (KkhConstAsh.HasuKbn.ROUNDUP == _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim())
                        {
                            //�z����.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, snziIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                            //�[���敪.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, snziIdx].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                        }
                        //���ד��́D�[��������"�؎̂�"�̏ꍇ.
                        else if (KkhConstAsh.HasuKbn.ROUNDDOWN == _spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim())
                        {
                            //�z����.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, snziIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                            //�[���敪.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, snziIdx].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                        }
                        //��L�ȊO�̏ꍇ�A�z�������Z�o����.
                        else
                        {
                            //���ד��́D���ϋ��z�A���ד��́D���ϋ��z�̍��v��0�ȊO�̏ꍇ.
                            if (seiShokei != 0 && seiSoGokei != 0)
                            {
                                /*
                                 * �z����.
                                 * ���ϋ��z / ���ϋ��z�̍��v) * 100.
                                 * ���������������傤�� 0.5 �̏ꍇ�A�ł��߂������ɒl���ۂ߂�.
                                 * 0.5�� 0�A1.5 �� 2
                                 */
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, snziIdx].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                            }
                        }
                    }
                    //�܂��n��V�[�g�ɖ����i��R�[�h�̏ꍇ.
                    else
                    {
                        //�i��(���i)�R�[�h��1����10�ȉ��̏ꍇ.
                        if (shohIdx >= 1 && shohIdx < 10)
                        {
                            //�i��(���i)�R�[�h��C���f�b�N�X�����Z.
                            shohIdx++;

                            //�i��R�[�h�����l�ݒ�.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, shohIdx].Value = hnshCd;

                            //���ד��́D�[��������"�؏グ"�̏ꍇ.
                            if (KkhConstAsh.HasuKbn.ROUNDUP.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //�z����.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value =
                                    Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //�[���敪.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                            }
                            //���ד��́D�[��������"�؎̂�"�̏ꍇ.
                            else if (KkhConstAsh.HasuKbn.ROUNDDOWN.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //�z����.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //�[���敪.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, shohIdx].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                            }
                            //��L�ȊO�̏ꍇ�A�z�������Z�o����.
                            else
                            {
                                //���ד��́D���ϋ��z�A���ד��́D���ϋ��z�̍��v��0�ȊO�̏ꍇ.
                                if (seiShokei != 0 && seiSoGokei != 0)
                                {
                                    /*
                                     * �z����.
                                     * ���ϋ��z / ���ϋ��z�̍��v) * 100.
                                     * ���������������傤�� 0.5 �̏ꍇ�A�ł��߂������ɒl���ۂ߂�.
                                     * 0.5�� 0�A1.5 �� 2.
                                     */
                                    spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shohIdx].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                                }
                            }
                        }
                        //�i��(���i)�R�[�h��10�ȏ�̏ꍇ.
                        else if (shohIdx >= 10)
                        {
                            //�i��R�[�h�����l�ݒ�.
                            spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, COLIDX_KLIST_SHOUHINCD_END].Value = hnshCd;

                            //���ד��́D�[��������"�؏グ"�̏ꍇ.
                            if (KkhConstAsh.HasuKbn.ROUNDUP.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //�z����.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, COLIDX_KLIST_SHOUHINCD_END].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //�[���敪.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, COLIDX_KLIST_SHOUHINCD_END].Value = KkhConstAsh.HasuKbn.ROUNDUP;
                            }
                            //���ד��́D�[��������"�؎̂�"�̏ꍇ.
                            else if (KkhConstAsh.HasuKbn.ROUNDDOWN.Equals(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HASUUSYORIKBN].Text.Trim()))
                            {
                                //�z����.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, COLIDX_KLIST_SHOUHINCD_END].Value = Double.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Text.Trim());
                                //�[���敪.
                                spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, COLIDX_KLIST_SHOUHINCD_END].Value = KkhConstAsh.HasuKbn.ROUNDDOWN;
                            }
                            //��L�ȊO�̏ꍇ�A�z�������Z�o����.
                            else
                            {
                                //int hnmaeGak = int.Parse(_spdDetailInput_Sheet1.Cells[j, DetailInputAsh.COLIDX_HNMAEGAK].Text.Trim().Replace(",", ""));

                                // ���ד��́D���ϋ��z�A���ד��́D���ϋ��z�̍��v��0�ȊO�̏ꍇ.
                                if (seiShokei != 0 && seiSoGokei != 0)
                                {
                                    //�z����.
                                    //   ���ϋ��z / ���ϋ��z�̍��v) * 100.
                                    //   ���������������傤�� 0.5 �̏ꍇ�A�ł��߂������ɒl���ۂ߂�.
                                    //      0.5�� 0�A1.5 �� 2
                                    //spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, shouhinColIndex].Value = Math.Round((hnmaeGak  / hnmaeGakGoukei) * 100);
                                    spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, COLIDX_KLIST_SHOUHINCD_END].Value = Math.Round((seiShokei / seiSoGokei) * 100);
                                }
                                //�[���敪.
                                //spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, COLIDX_KLIST_SHOUHINCD_END].Value = string.Empty;
                            }

                        }

                    }

                }

                //���v��������.
                seiShokei = 0M;

                //���i�R�[�h��ێ����Ă���.
                hnshCd2[j] = hnshCd;
            }

            //�`�F�b�N�{�b�N�X�̐ݒ�.
            //���ד��̓V�[�g�̍s�����J��Ԃ�.
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                //�n��V�[�g�̍s�����J��Ԃ�.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    int count = 0;
                    string dtlShohinCd = string.Empty;
                    //�n��V�[�g�̏��i�R�[�h�ɓ��͒l������񕪌J��Ԃ�.
                    for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= shohIdx; colIndex++)
                    {
                        //�ǃR�[�h�s.
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
                        //if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value))
                        //{
                                /* 2013/01/29 JSE A.Naito MOD Start */
                                //���׍s��9�s�ȏ�̏ꍇ.
                                //if (colIndex > 9)
                                ////if (i > 9)
                                //{
                                    //�i��(���i)�R�[�h��̍ŏI��ɓ��͒l������ꍇ.
                                    //if (shohIdx == COLIDX_KLIST_SHOUHINCD_END)
                                    //{
                                    //    //�ǃR�[�h�Ƀ`�F�b�N����.
                                    //    spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_END].Value = true;
                                    //}
                                    //else
                                    //{
                                    //���ׂƌn��̕i��(���i)��R�[�h������̏ꍇ.
                                    //if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                    //{
                                    //    spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                    //}
                                    ////}
                        //�ǃR�[�h���ݒ肪����ꍇ.
                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_KYOKUCD].Value != null)
                        {
                            //�ǃR�[�h����v.
                            if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_KYOKUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value))
                            {
                                //���׍s��9�s�ȏ�̏ꍇ.
                                if (colIndex > 9)
                                {
                                    //���ׂƌn��̕i��(���i)��R�[�h������̏ꍇ.
                                    if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                                    {
                                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                        {
                                            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                        }
                                    }
                                    else
                                    {
                                        if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value) == "")
                                        {
                                            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;

                                        }
                                    }
                                }
                                /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */
                                /* 2013/01/29 JSE A.Naito MOD End */
                                else
                                {
                                    //���ׂƌn��̕i��(���i)��R�[�h������̏ꍇ.
                                    /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
                                    //if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                    //{
                                    //    //����.
                                    //    if (count == 0)
                                    //    {
                                    //        spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_FIRST].Value = true;
                                    //    }
                                    //    //����ȍ~.
                                    //    else if (count > 0)
                                    //    {
                                    //        if (dtlShohinCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                    //        {
                                    //            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                    //        }
                                    //    }
                                    //}
                                    if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                                    {
                                        //���ׂƌn��̕i��(���i)��R�[�h������̏ꍇ.
                                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim() == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                        {
                                            //����.
                                            if (count == 0)
                                            {
                                                spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_FIRST].Value = true;
                                            }
                                            //����ȍ~.
                                            else if (count > 0)
                                            {
                                                if (dtlShohinCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                                {
                                                    spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //���ׂƌn��̕i��(���i)��R�[�h������̏ꍇ(�󕶎�).
                                        if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value) == "")
                                        {
                                            //����.
                                            if (count == 0)
                                            {
                                                spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_SHOUHINCD_FIRST].Value = true;
                                            }
                                            //����ȍ~.
                                            else if (count > 0)
                                            {
                                                if (dtlShohinCd == KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value))
                                                {
                                                    spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value = true;
                                                }
                                            }
                                        }
                                    }
                                    /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */
                                }
                            }
                        }
                        count++;
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD Start */
                        //dtlShohinCd = _spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                        if (_spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value != null)
                        {
                            dtlShohinCd = _spdDetailInput_Sheet1.Cells[i, DetailInputAsh.COLIDX_HINSYUCD].Value.ToString().Trim();
                        }
                        /* 2013/02/01 ����1�s��NUll�Ή� HLC T.Sonobe MOD End */
                    }
                }
            }
        }
        #endregion �e�R���g���[���̕ҏW����.

        #region �ǃ}�X�^����ݒ肷��.
        /// <summary>
        /// �ǃ}�X�^����ݒ肷��.
        /// </summary>
        private void setKyokuInfo(string key)
        {
            //�����ݒ�.
            MasterMaintenance.MasterDataVORow[] rows;
            List<string> lstKeys;
            List<string> lstValues;

            //�ǃ}�X�^���擾.
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            result = process.FindMasterByCond(_naviParam.strEsqId,
                                            _naviParam.strEgcd,
                                            _naviParam.strTksKgyCd,
                                            _naviParam.strTksBmnSeqNo,
                                            _naviParam.strTksTntSeqNo,
                                            key,
                                            "");
            MasterMaintenance.MasterDataVODataTable dt = result.MasterDataSet.MasterDataVO;
            //�f�[�^�e�[�u���̃R�s�[���쐬.
            MasterMaintenance.MasterDataVODataTable dt2 = (MasterMaintenance.MasterDataVODataTable)dt.Clone();
            DataView dv = new DataView(dt);
            dv.Sort = "Column1";
            foreach (DataRowView drv in dv)
            {
                dt2.ImportRow(drv.Row);
            }
            rows = (MasterMaintenance.MasterDataVORow[])dt2.Select();
            lstKeys = new List<string>();
            lstValues = new List<string>();
            lstKeys.Add(string.Empty);
            lstValues.Add(string.Empty);

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column1 + " " + row.Column4 + " " + row.Column2);
            }

            //�ǃ}�X�^���ݒ�.
            _itemKyokuCd = lstKeys.ToArray();
            _itemKyokuNm = lstValues.ToArray();
        }
        #endregion �ǃ}�X�^����ݒ肷��.

        #region ���i�}�X�^����ݒ肷��.
        /// <summary>
        /// ���i�}�X�^����ݒ肷��.
        /// </summary>
        private void setShouhinInfo()
        {
            //�����ݒ�.
            MasterMaintenance.MasterDataVORow[] rows;
            List<string> lstKeys;
            List<string> lstValues;

            //���i�}�X�^���擾.
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            result = process.FindMasterByCond(_naviParam.strEsqId,
                                            _naviParam.strEgcd,
                                            _naviParam.strTksKgyCd,
                                            _naviParam.strTksBmnSeqNo,
                                            _naviParam.strTksTntSeqNo,
                                            Isid.KKH.Ash.Utility.KkhConstAsh.MasterKey.SYOHIN,
                                            "");
            _dsShouhinInfo = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])_dsShouhinInfo.MasterDataVO.Select();
            lstKeys = new List<string>();
            lstValues = new List<string>();
            lstKeys.Add(string.Empty);
            lstValues.Add(string.Empty);

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column1 + " " + row.Column2);
            }

            //���i�}�X�^�\�[�g.
            lstKeys.Sort(); 
            lstValues.Sort(); 

            //���i�}�X�^���ݒ�.
            _itemShouhinCd = lstKeys.ToArray();
            _itemShouhinNm = lstValues.ToArray();
        }
        #endregion ���i�}�X�^����ݒ肷��.

        #region �[���敪����ݒ肷��.
        /// <summary>
        /// �[���敪����ݒ肷��.
        /// </summary>
        private void setHasuKbn()
        {
            //�����ݒ�.
            List<string> lstKeys;
            List<string> lstValues;
            lstKeys = new List<string>();
            lstValues = new List<string>();

            lstKeys.Add(string.Empty);
            lstKeys.Add(KkhConstAsh.HasuKbn.ROUNDUP);
            lstKeys.Add(KkhConstAsh.HasuKbn.ROUNDDOWN);

            lstValues.Add(string.Empty);
            lstValues.Add(KkhConstAsh.HasuNm.ROUNDUP);
            lstValues.Add(KkhConstAsh.HasuNm.ROUNDDOWN);

            //�e���r�ǃ}�X�^���ݒ�.
            _itemHasuKbnCd = lstKeys.ToArray();
            _itemHasuKbnNm = lstValues.ToArray();
        }
        #endregion �[���敪����ݒ肷��.

        #region �R���{�{�b�N�X�ݒ�.
        /// <summary>
        /// �R���{�{�b�N�X�ݒ�.
        /// </summary>
        private void setComboBox(int rowIndex, int colIndex, string[] keyArray, string[] nameArray)
        {
            ComboBoxCellType type = new ComboBoxCellType();
            type.ItemData = keyArray;
            type.Items = nameArray;
            type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
            type.Editable = false;
            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].CellType = type;
        }
        #endregion �R���{�{�b�N�X�ݒ�.

        #region �`�F�b�N�{�b�N�X�ݒ�.
        /// <summary>
        /// �`�F�b�N�{�b�N�X�ݒ�.
        /// </summary>
        private void setCheckBox(int rowIndex, int colIndex)
        {
            CheckBoxCellType type = new CheckBoxCellType();
            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].CellType = type;
            spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].HorizontalAlignment = CellHorizontalAlignment.Center;
        }
        #endregion �`�F�b�N�{�b�N�X�ݒ�.

        #region ���̓`�F�b�N.
        /// <summary>
        /// ���̓`�F�b�N.
        /// </summary>
        private Boolean checkInput()
        {
            //�����ݒ�.
            _shouhinCdCnt = 0;
            decimal delHaibunRituSum = 0;

            //���i�R�[�h�񐔕��A�J��Ԃ�.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
            {
                //���i�R�[�h.
                String strShouhinCd = KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value).Trim();

                //���i�R�[�h�����ݒ�̏ꍇ.
                if (strShouhinCd.Equals(string.Empty))
                {
                    continue;
                }

                //���i�R�[�h�������J�E���g�A�b�v.
                _shouhinCdCnt++;

                //�z���������Z.
                if (spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value != null)
                {
                    delHaibunRituSum = delHaibunRituSum + decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
                }
                //�ǃR�[�h�̍s�����A�J��Ԃ�.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    //�`�F�b�N�Ȃ��̏ꍇ.
                    if (spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value == null || spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value.ToString() == "False")
                    {
                        continue;
                    }
                    /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki MOD Start */
                    //�e���r�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ.
                    //if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd))
                    if (KkhConstAsh.BaitaiCd.TV_TIME.Equals(_naviParam.BaitaiCd)|| KkhConstAsh.BaitaiCd.TV_NETSPOT.Equals(_naviParam.BaitaiCd))
                    /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki MOD End */
                    {
                        //�d���`�F�b�N.
                        String strKyokuCode = KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value).Trim();
                        if (!checkDuplication(colIndex, rowIndex, strShouhinCd, strKyokuCode))
                        {
                            //�G���[���b�Z�[�W��\��.
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0068, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            //���i��1�����I������Ă��Ȃ��ꍇ.
            if (_shouhinCdCnt == 0)
            {
                return false;
            }

            //�z�����̍��v��100�ȊO�̏ꍇ.
            if (delHaibunRituSum != 100)
            {
                //�G���[���b�Z�[�W��\��.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0074, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                return false;
            }

            _bunbo = 0;
            _haibunrituArray = new decimal[_shouhinCdCnt];
            //���i�R�[�h�񐔕��A�J��Ԃ�.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= _shouhinCdCnt; colIndex++)
            {
                if (spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value == null || decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim()) == 0)
                {
                    //�G���[���b�Z�[�W��\��.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0076, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                    return false;
                }

                //�z������z��Ɋi�[.
                _haibunrituArray[colIndex - 1] = decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
                //��������Z.
                _bunbo = _bunbo + decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
            }

            _hasuKbn = new String[_shouhinCdCnt];
            //���i�R�[�h�񐔕��A�J��Ԃ�.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= _shouhinCdCnt; colIndex++)
            {
                //�����ݒ�.
                decimal delHaibunRitu = decimal.Parse(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HAIBUNRITU, colIndex].Value.ToString().Trim());
                decimal delHaibunRituRoundDown = Math.Floor(delHaibunRitu);
                _hasuKbn[colIndex - 1] = KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, colIndex].Value).Trim();

                //�����_�ȉ��̓��͂���ŁA���[���敪��ݒ肵�Ă��Ȃ��ꍇ.
                if (delHaibunRitu != delHaibunRituRoundDown && KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, colIndex].Value).Trim().Equals(string.Empty))
                {
                    //�G���[���b�Z�[�W��\��.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0057, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                    return false;
                }

                //�[���敪��ݒ肵�Ă��Ȃ����i�R�[�h����O�ɁA�[���敪��ݒ肵�Ă��鏤�i�R�[�h�񂪂���ꍇ.
                for (int i = COLIDX_KLIST_SHOUHINCD_FIRST; i <= colIndex - 1; i++)
                {
                    if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, colIndex].Value).Trim().Equals(string.Empty) && !KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_HASUKBN, i].Value).Trim().Equals(string.Empty)){
                        //�G���[���b�Z�[�W��\��.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0057, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion ���̓`�F�b�N.

        #region �d���`�F�b�N.
        /// <summary>
        /// �d���`�F�b�N.
        /// </summary>
        private Boolean checkDuplication(int intSubjectColIndex, int intSubjectRowIndex, String strShouhinCd, String strKyokuCode)
        {
            //���i�R�[�h�񐔕��A�J��Ԃ�.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= COLIDX_KLIST_SHOUHINCD_END; colIndex++)
            {
                //���i�R�[�h�����ݒ�̏ꍇ.
                if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value).Trim().Equals(string.Empty))
                {
                    continue;
                }
                //�ǃR�[�h�̍s�����A�J��Ԃ�.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    //�`�F�b�N�Ȃ��̏ꍇ.
                    if (spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value == null || spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value.ToString() == "False")
                    {
                        continue;
                    }
                    //�d���`�F�b�N�Ώۂ̃Z���̏ꍇ.
                    if (colIndex == intSubjectColIndex && rowIndex == intSubjectRowIndex)
                    {
                        continue;
                    }
                    if (KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value).Trim().Equals(strShouhinCd) && KKHUtility.ToString(spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value).Trim().Equals(strKyokuCode))
                    {
                        //�d������.
                        return false;
                    }
                }
            }

            //�d���Ȃ�.
            return true;
        }
        #endregion �d���`�F�b�N.

        #region ���ד��͉�ʕҏW.
        /// <summary>
        /// ���ד��͉�ʕҏW.
        /// </summary>
        private void editDetailInput()
        {
            /* 2014/08/15 HLC ��(JANG) ADD Start */
            DetailDSAsh.KeyKyokuBangumiCdDataTable dtKKBC = null;
            //�A�T�q�r�[���Ńe���r�^�C���A�܂��̓e���r�l�b�g�X�|�b�g�̏ꍇ�A�g���}�X�^�[�̏����擾.
            if (_naviParam.strTksKgyCd == UserManualHelper.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6) 
                && (_naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD Start */
                || _naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT))
                /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD End */
            {
                // �}�X�^�[����L�[�ǂ̔ԑg�R�[�h���擾.
                DetailAshProcessController processController = DetailAshProcessController.GetInstance();
                DetailAshProcessController.KeyKyokuBangumiCdParam param = new DetailAshProcessController.KeyKyokuBangumiCdParam();
                param.egCd = _naviParam.strEgcd;
                param.tksKgyCd = _naviParam.strTksKgyCd;
                param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
                param.baitaiCd = Isid.KKH.Ash.View.Report.ReportAshByMedium.KYKCD_TV;

                FindKeyKyokuBangumiCdServiceResult result = processController.FindKeyKyokuBangumiCd(param);
                dtKKBC = result.DetailAshDataSet.KeyKyokuBangumiCd;
            }
            /* 2014/08/15 HLC ��(JANG) ADD End */
            
            //�����s����ꍇ.
            if (_spdDetailInput_Sheet1.RowCount > 1)
            {
                //�擪�s�ȊO���폜.
                _spdDetailInput_Sheet1.RemoveRows(1, _spdDetailInput_Sheet1.RowCount - 1);
            }
            //�ǃR�[�h�����J�E���^.
            int kyokuCdCnt = 0;

            //���i�R�[�h�񐔕��A�J��Ԃ�.
            for (int colIndex = COLIDX_KLIST_SHOUHINCD_FIRST; colIndex <= _shouhinCdCnt; colIndex++)
            {
                //�ǃR�[�h�̍s�����A�J��Ԃ�.
                for (int rowIndex = ROWIDX_KLIST_KYOKUCD_FIRST; rowIndex < spdKyokuSentakuList_Sheet1.RowCount; rowIndex++)
                {
                    //�`�F�b�N����̏ꍇ.
                    if (spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value != null && spdKyokuSentakuList_Sheet1.Cells[rowIndex, colIndex].Value.ToString() == "True")
                    {
                        //���ד��͉�ʂ̍s�ǉ�(1�s�ǉ�����).
                        _spdDetailInput_Sheet1.AddRows(_spdDetailInput_Sheet1.RowCount, 1);

                        //���ד��̓X�v���b�h�̗񐔕��A�J��Ԃ�.
                        for (int detailInputColIndex = 0; detailInputColIndex <= DetailInputAsh.COLIDX_KEYKYOKUCD; detailInputColIndex++)
                        {
                            //���l���ڂ̏ꍇ.
                            if (detailInputColIndex == DetailInputAsh.COLIDX_HNMAEGAK ||
                                detailInputColIndex == DetailInputAsh.COLIDX_HNNERT ||
                                detailInputColIndex == DetailInputAsh.COLIDX_SEIGAK ||
                                detailInputColIndex == DetailInputAsh.COLIDX_ZEIRITSU ||
                                /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD Start */
                                detailInputColIndex == DetailInputAsh.COLIDX_NEBIKIGAKU ||
                                detailInputColIndex == DetailInputAsh.COLIDX_ZEIGAKU ||
                                /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD End */
                                detailInputColIndex == DetailInputAsh.COLIDX_HASUUSYORIKBN ||
                                detailInputColIndex == DetailInputAsh.COLIDX_NYUURYOKUHIRITSU)
                            {
                                //O�ŏ�����.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, detailInputColIndex].Value = 0;
                            }

                            /* 2014/08/15 HLC ��(JANG) ADD Start */
                            // �A�T�q�r�[���̃e���r�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ�A�ԑg�R�[�h��ݒ�.
                            else if (detailInputColIndex == DetailInputAsh.COLIDX_BANGUMICD &&
                                _naviParam.strTksKgyCd == UserManualHelper.TksKgyCode.TksKgyCode_AshBear.Substring(0, 6) 
                                && (_naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                                /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD Start */
                                || _naviParam.BaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT))
                                /* 2015/06/08 �ǉ��Ή� HLC K.Fujisaki ADD End */
                            {
                                // �󒍃f�[�^�ɃL�[�ǂ��ݒ肳��ĂȂ��ꍇ�̔ԑg�R�[�h�͊e�s�̕����ǂ̃L�[�ǂ̃R�[�h��ݒ�.
                                if (_dataRow.hb1Field1 == "")
                                {
                                    DetailDSAsh.KeyKyokuBangumiCdRow[] rowKKBC = (DetailDSAsh.KeyKyokuBangumiCdRow[])dtKKBC.
                                        Select("KYOKUCD = '" + spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value + "'");
                                    _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = rowKKBC[0].KEYBANGUMICD;
                                }
                                // �󒍃f�[�^�ɃL�[�ǂ��ݒ肳��Ă���ꍇ�͂��ׂĂ̍s�̔ԑg�R�[�h�ɂ��̃L�[�ǂ̃R�[�h��ݒ�.
                                else
                                {
                                    DetailDSAsh.KeyKyokuBangumiCdRow[] rowKKBC = (DetailDSAsh.KeyKyokuBangumiCdRow[])dtKKBC.
                                        Select("KYOKURYAKUSYOU = '" + _dataRow.hb1Field1.Trim() + "'");
                                    /* 2015/06/08 HLC K.Fujisaki MOD Start */
                                    //_spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = rowKKBC[0].KEYBANGUMICD;
                                    if (rowKKBC.Length == 0)
                                    {
                                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = "";
                                    }
                                    else
                                    {
                                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_BANGUMICD].Value = rowKKBC[0].KEYBANGUMICD;
                                    }
                                    /* 2015/06/08 HLC K.Fujisaki MOD End */
                                }
                            }
                            /* 2014/08/15 HLC ��(JANG) ADD End */

                            //��L�ȊO�̏ꍇ.
                            else
                            {
                                //���ד��͉�ʂ̐擪�s�̒l��ݒ�.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, detailInputColIndex].Value = _spdDetailInput_Sheet1.Cells[0, detailInputColIndex].Value;
                            }
                        }

                        //�ǃR�[�h�ݒ�.
                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_KYOKUCD].Value = spdKyokuSentakuList_Sheet1.Cells[rowIndex, COLIDX_KLIST_KYOKUCD].Value;

                        //���i�R�[�h�ݒ�.
                        _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HINSYUCD].Value = spdKyokuSentakuList_Sheet1.Cells[ROWIDX_KLIST_SHOUHINCD, colIndex].Value;

                        if (kyokuCdCnt == 0)
                        {
                            //���ϋ��z.
                            decimal delSeikyu = _dataRow.hb1ToriGak;
                            decimal delCurResult = delSeikyu * _haibunrituArray[colIndex - 1] / _bunbo;

                            /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD Start */
                            //�l���z.
                            decimal delNebikiGaku = _dataRow.hb1NeviGak * _haibunrituArray[colIndex - 1] / _bunbo;
                            //����Ŋz.
                            decimal delZeiGaku = _dataRow.hb1SzeiGak * _haibunrituArray[colIndex - 1] / _bunbo;
                            /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD End */

                            //�؂�グ.
                            if (_hasuKbn[colIndex - 1].Equals(KkhConstAsh.HasuKbn.ROUNDUP))
                            {
                                //���ϋ��z.
                                delCurResult = Math.Truncate(delCurResult + new decimal(0.9));
                                /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD Start */
                                //�l���z.
                                delNebikiGaku = Math.Truncate(delNebikiGaku + new decimal(0.9));
                                //����Ŋz.
                                delZeiGaku = Math.Truncate(delZeiGaku + new decimal(0.9));
                                /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD End */
                            }
                            //�؂�̂�.
                            else if (_hasuKbn[colIndex - 1].Equals(KkhConstAsh.HasuKbn.ROUNDDOWN))
                            {
                                //���ϋ��z.
                                delCurResult = Math.Truncate(delCurResult);
                                /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD Start */
                                //�l���z.
                                delNebikiGaku = Math.Truncate(delNebikiGaku);
                                //����Ŋz.
                                delZeiGaku = Math.Truncate(delZeiGaku);
                                /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD End */
                            }
                            //�ݒ�Ȃ�.
                            else
                            {
                            }

                            //���ϋ��z.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HNMAEGAK].Value = delCurResult;
                            /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD Start */
                            //�l���z.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_NEBIKIGAKU].Value = delNebikiGaku;
                            //����Ŋz.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_ZEIGAKU].Value = delZeiGaku;
                            /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga ADD End */

                            //�[���敪����łȂ��ꍇ.
                            if (_hasuKbn[colIndex - 1] != "") 
                            {
                                //�[�������敪.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HASUUSYORIKBN].Value = _hasuKbn[colIndex - 1];
                                //���͔䗦.
                                _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_NYUURYOKUHIRITSU].Value = _haibunrituArray[colIndex - 1];
                            }

                            //�l����.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_HNNERT].Value = _dataRow.hb1NeviRitu.ToString().Trim();
                            /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga MOD Start */
                            //�������z(���ϋ��z - �l���z).
                            //_spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_SEIGAK].Value = Math.Truncate(delCurResult - (delCurResult * (_dataRow.hb1NeviRitu / 100)));
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_SEIGAK].Value = Math.Truncate(delCurResult - delNebikiGaku);
                            /* 2016/12/19 �A�T�q����őΉ� HLC K.Soga MOD End */
                            //����ŗ�.
                            _spdDetailInput_Sheet1.Cells[_spdDetailInput_Sheet1.RowCount - 1, DetailInputAsh.COLIDX_ZEIRITSU].Value = _dataRow.hb1SzeiRitu.ToString().Trim();
                        }

                        //�ǃR�[�h�����J�E���^�̍X�V.
                        kyokuCdCnt++;
                    }
                }

                //�ǃR�[�h�����J�E���^�̏�����.
                kyokuCdCnt = 0;
            }

            //�擪�s���폜(�ҏW�p�Ɏg�p).
            _spdDetailInput_Sheet1.RemoveRows(0, 1);
        }
        #endregion ���ד��͉�ʕҏW.
        #endregion ���\�b�h.
    }
}