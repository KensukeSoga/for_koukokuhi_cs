using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Main.Utility
{
    class KkhConstMain
    {
        #region �萔

        /// <summary>
        /// �J���m�F�p���
        /// </summary>
        public const string RELEASE_SYBT = "999";

        /// <summary>
        /// �J���m�F�pFIELD1
        /// </summary>
        public const string TF_FLD1 = "001";

        #endregion �萔

        #region �\����

        /// <summary>
        /// ���Ӑ�I���X�v���b�h�̗�
        /// </summary>
        public struct CustomerSelectCol
        {
            /// <summary>
            /// ���Ӑ��ƃR�[�h
            /// </summary>
            public const int TKSKGYCD = 0;
            /// <summary>
            /// ���Ӑ敔��SEQNO
            /// </summary>
            public const int TKSBMNSEQNO = 1;
            /// <summary>
            /// ���Ӑ�S��SEQNO
            /// </summary>
            public const int TKSTNTSEQNO = 2;
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public const int TKSCD = 3;
            /// <summary>
            /// ���Ӑ於
            /// </summary>
            public const int TKSNAME = 4;
            /// <summary>
            /// �S���g�D��
            /// </summary>
            public const int TNTSIKNAME = 5;
        }

        /// <summary>
        /// �t���O
        /// </summary>
        public struct Flag
        {
            /// <summary>
            /// OFF
            /// </summary>
            public const string OFF = "0";
            /// <summary>
            /// ON
            /// </summary>
            public const string ON = "1";
        }

        #endregion
    }
}
