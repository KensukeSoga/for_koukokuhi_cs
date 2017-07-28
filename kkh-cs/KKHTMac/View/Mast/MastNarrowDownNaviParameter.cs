using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Mac.View.Mast
{
    public class MastNarrowDownNaviParameter : KKHNaviParameter
    {
        #region "�v���p�e�B"
        /// <summary>
        /// �X�܃R�[�h
        /// </summary>
        private string _tenCd;
        /// <summary>
        /// �X�܃R�[�h
        /// </summary>
        public string tenCd
        {
            get { return _tenCd; }
            set { _tenCd = value; }
        }

        /// <summary>
        /// �X�܃R�[�h2
        /// </summary>
        private string _tenCd2;
        /// <summary>
        /// �X�܃R�[�h2
        /// </summary>
        public string tenCd2
        {
            get { return _tenCd2; }
            set { _tenCd2 = value; }
        }

        /// <summary>
        /// �X�܃R�[�h�R���{�{�b�N�X
        /// </summary>
        private int  _tenCdCmb;
        /// <summary>
        /// �X�܃R�[�h�R���{�{�b�N�X
        /// </summary>
        public int tenCdCmb
        {
            get { return _tenCdCmb; }
            set { _tenCdCmb = value; }
        }

        /// <summary>
        /// �X�ܖ�
        /// </summary>
        private string _tenName;
        /// <summary>
        /// �X�ܖ�
        /// </summary>
        public string tenName
        {
            get { return _tenName; }
            set { _tenName = value; }
        }

        /// <summary>
        /// �e���g���[�֓�
        /// </summary>
        private bool _terKanto;
        /// <summary>
        /// �e���g���[�֓�
        /// </summary>
        public bool terKanto
        {
            get { return _terKanto; }
            set { _terKanto = value; }
        }

        /// <summary>
        /// �e���g���[�֐�
        /// </summary>
        private bool _terKansai;
        /// <summary>
        /// �e���g���[�֐�
        /// </summary>
        public bool terKansai
        {
            get { return _terKansai; }
            set { _terKansai = value; }
        }

        /// <summary>
        /// �e���g���[����
        /// </summary>
        private bool _terTyuou;
        /// <summary>
        /// �e���g���[����
        /// </summary>
        public bool terTyuou
        {
            get { return _terTyuou; }
            set { _terTyuou = value; }
        }

        /// <summary>
        /// �e���g���[���̑�
        /// </summary>
        private bool _terSonota;
        /// <summary>
        /// �e���g���[���̑�
        /// </summary>
        public bool terSonota
        {
            get { return _terSonota; }
            set { _terSonota = value; }
        }

        /// <summary>
        /// �X�܋敪�n��{��
        /// </summary>
        private bool _kbnTikuhonbu;
        /// <summary>
        /// �X�܋敪�n��{��
        /// </summary>
        public bool kbnTikuhonbu
        {
            get { return _kbnTikuhonbu; }
            set { _kbnTikuhonbu = value; }
        }

        /// <summary>
        /// �X�܋敪MC���c�X
        /// </summary>
        private bool _kbnMc;
        /// <summary>
        /// �X�܋敪MC���c�X
        /// </summary>
        public bool kbnMc
        {
            get { return _kbnMc; }
            set { _kbnMc = value; }
        }

        /// <summary>
        /// �X�܋敪���C�Z���V�[
        /// </summary>
        private bool _kbnLicensee;
        /// <summary>
        /// �X�܋敪���C�Z���V�[
        /// </summary>
        public bool kbnLicensee
        {
            get { return _kbnLicensee; }
            set { _kbnLicensee = value; }
        }

        /// <summary>
        /// �X�܋敪���̑�
        /// </summary>
        private bool _kbnSonota;
        /// <summary>
        /// �X�܋敪���̑�
        /// </summary>
        public bool kbnSonota
        {
            get { return _kbnSonota; }
            set { _kbnSonota = value; }
        }

        #endregion "�v���p�e�B"

    }
}