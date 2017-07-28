using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;

using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Acom.ProcessController.Claim;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Acom.Utility;

namespace Isid.KKH.Acom.View.Claim
{
    /// <summary>
    /// �����f�[�^�o�� 
    /// </summary>
    public partial class ClaimForm : KKHForm
    {
        #region �萔 

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "ClaiAcom";

        ///// <summary>
        ///// ���[�ݒ���擾�L�[�F002 
        ///// </summary>
        //private const string KV7_SYBT = "002";

        /// <summary>
        /// ���[�ۑ���擾�p�L�[
        /// </summary>
        private const String SYSTEM_KEY_SAVEFILE_PATH = "003";

        /// <summary>
        ///// �����f�[�^�o�́Q�N���f�B���N�g�� 
        ///// </summary>
        //private const string CLAIM_SFD_INITDIR = @"C:\";

        /// <summary>
        /// �����f�[�^�o�́Q�N���f�B���N�g�� 
        /// </summary>
        private const string CLAIM_SFD_INITDIRTMP = @"C:\Temp\";
        /// <summary>
        /// �����f�[�^�o�́Q�t�@�C�� 
        /// </summary>
        private const string CLAIM_SFD_FILENAME = "Adntks_0002";
        /// <summary>
        /// �����f�[�^�o�́Q�t�@�C���g���q 
        /// </summary>
        private const string CLAIM_SFD_EXT = ".txt";
        /// <summary>
        /// �����f�[�^�o�́Q�t�B���^ 
        /// </summary>
        private const string CLAIM_SFD_FILTER = "�e�L�X�g �t�@�C�� (*.txt)|*.txt";
        /// <summary>
        /// �����f�[�^�o�́Q�^�C�g�� 
        /// </summary>
        private const string CLAIM_SFD_TITLE = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";
        /// <summary>
        /// ��ʁQS 
        /// </summary>
        private const string SYBT_S = "S";
        /// <summary>
        /// ��ʁQT 
        /// </summary>
        private const string SYBT_T = "T";
        /// <summary>
        /// ��ʁQH 
        /// </summary>
        private const string SYBT_H = "H";

        #endregion �萔 

        #region �\���� 

        /// <summary>
        /// �����敪���̂̍\���� 
        /// </summary>
        private struct ShoriKbnNm
        {
            /// <summary>
            /// ���o�� 
            /// </summary>
            internal const string MiSyutu = "���o��";
            /// <summary>
            /// �����M 
            /// </summary>
            internal const string MiSoushin = "�����M";
            /// <summary>
            /// ���M�� 
            /// </summary>
            internal const string SoushinZumi = "���M��";
            /// <summary>
            /// �ꕔ�o�͍� 
            /// </summary>
            internal const string IchbuSyutuZumi = "�ꕔ�o�͍�";
        }

        /// <summary>
        /// ����/�����ԍ� �ꗗ�̃J�����ԍ��\���� 
        /// </summary>
        private struct ClaimNoListColNo
        {
            /// <summary>
            /// �����敪
            /// </summary>
            internal const int SHORIKBN = 0;
            /// <summary>
            /// �o�͑I��
            /// </summary>
            internal const int OUTSELECT = 1;
            /// <summary>
            /// �˗��ԍ� 
            /// </summary>
            internal const int IRAINO = 2;
            /// <summary>
            /// �������ԍ�
            /// </summary>
            internal const int SEINO = 3;
            /// <summary>
            /// ���������s�� 
            /// </summary>
            internal const int SEIYYMM = 4;
            /// <summary>
            /// �o�͓��� 
            /// </summary>
            internal const int OUTDATE = 7;
        }

        /// <summary>
        /// ����/�����ԍ� ���وꗗ�̃J�����ԍ��\���� 
        /// </summary>
        private struct ClaimDiffListColNo
        {
            /// <summary>
            /// ��� 
            /// </summary>
            internal const int SYBT = 0;
            /// <summary>
            /// �˗��ԍ� 
            /// </summary>
            internal const int IRAINO = 1;
            /// <summary>
            /// �˗��s�ԍ� 
            /// </summary>
            internal const int IRAIGYONO = 2;
            /// <summary>
            /// �����N���� 
            /// </summary>
            internal const int SEIYYMM = 6;
            /// <summary>
            /// �������ԍ� 
            /// </summary>
            internal const int SEINO = 7;
            /// <summary>
            /// ���e�敪 
            /// </summary>
            internal const int NAIYOKBN = 8;
            /// <summary>
            /// �������s�ԍ� 
            /// </summary>
            internal const int SEIGYONO = 9;
            /// <summary>
            /// ���i�敪 
            /// </summary>
            internal const int SYOHINKBN = 11;
            /// <summary>
            /// �E�v�R�[�h 
            /// </summary>
            internal const int TEKIYOCD = 12;
            /// <summary>
            /// �}�̃R�[�h 
            /// </summary>
            internal const int BAITAICD = 13;
            /// <summary>
            /// ���f�B�A�R�[�h 
            /// </summary>
            internal const int MEDIACD = 14;
            /// <summary>
            /// �`�ԋ敪�R�[�h 
            /// </summary>
            internal const int KEITAIKBNCD = 17;
            /// <summary>
            /// �`�ԋ敪���� 
            /// </summary>
            internal const int KEITAIKBNNM = 18;
            /// <summary>
            /// CM�b����1 
            /// </summary>
            internal const int CMNAME1 = 19;
            /// <summary>
            /// CM�b����2 
            /// </summary>
            internal const int CMNAME2 = 20;
            /// <summary>
            /// CM�b����3 
            /// </summary>
            internal const int CMNAME3 = 21;
            /// <summary>
            /// CM�b����4 
            /// </summary>
            internal const int CMNAME4 = 22;
            /// <summary>
            /// ���e����1 
            /// </summary>
            internal const int NAIYONAME1 = 23;
            /// <summary>
            /// ���e����2 
            /// </summary>
            internal const int NAIYONAME2 = 24;
            /// <summary>
            /// ���e����3 
            /// </summary>
            internal const int NAIYONAME3 = 25;
            /// <summary>
            /// ���e����4 
            /// </summary>
            internal const int NAIYONAME4 = 26;
            /// <summary>
            /// �ԑg������1 
            /// </summary>
            internal const int BNGMNAME1 = 27;
            /// <summary>
            /// �ԑg������2 
            /// </summary>
            internal const int BNGMNAME2 = 28;
            /// <summary>
            /// �ԑg������3 
            /// </summary>
            internal const int BNGMNAME3 = 29;
            /// <summary>
            /// �ԑg������4 
            /// </summary>
            internal const int BNGMNAME4 = 30;
            /// <summary>
            /// �f�ڏꏊ�R�[�h 
            /// </summary>
            internal const int KEISAIBASCD = 31;
            /// <summary>
            /// �f�ڏꏊ���� 
            /// </summary>
            internal const int KEISAIBASNM = 32;
            /// <summary>
            /// ���1�R�[�h 
            /// </summary>
            internal const int SYBT1CD = 33;
            /// <summary>
            /// ���1���� 
            /// </summary>
            internal const int SYBT1NM = 34;
            /// <summary>
            /// ���2�R�[�h 
            /// </summary>
            internal const int SYBT2CD = 35;
            /// <summary>
            /// ���2���� 
            /// </summary>
            internal const int SYBT2NM = 36;
            /// <summary>
            /// �F���R�[�h 
            /// </summary>
            internal const int SISACD = 37;
            /// <summary>
            /// �F������ 
            /// </summary>
            internal const int SISANM = 38;
            /// <summary>
            /// �T�C�Y�R�[�h 
            /// </summary>
            internal const int SIZECD = 39;
            /// <summary>
            /// �X�y�[�X�R�[�h 
            /// </summary>
            internal const int SPACECD = 40;
            /// <summary>
            /// �T�C�Y����
            /// </summary>
            internal const int SIZENM = 41;
            /// <summary>
            /// ��ʌf�ڃR�[�h 
            /// </summary>
            internal const int KOTUKEICD = 42;
            /// <summary>
            /// ��ʌf�ږ��� 
            /// </summary>
            internal const int KOTUKEINM = 43;
            /// <summary>
            /// ���� 
            /// </summary>
            internal const int KIKAN = 44;
            /// <summary>
            /// �f�ډ� 
            /// </summary>
            internal const int KEISAIKAISU = 45;
            /// <summary>
            /// ���z 
            /// </summary>
            internal const int KINGAK = 49;
            /// <summary>
            /// ����� 
            /// </summary>
            internal const int ANBUNSYBT = 52;
        }

        /// <summary>
        /// �����f�[�^ �ꗗ�̃J�����ԍ��\���� 
        /// </summary>
        private struct ClaimListColNo
        {
            /// <summary>
            /// ��� 
            /// </summary>
            internal const int SYBT = 0;
            /// <summary>
            /// �˗��ԍ� 
            /// </summary>
            internal const int IRAINO = 1;
            /// <summary>
            /// �˗��s�ԍ� 
            /// </summary>
            internal const int IRAIGYONO = 2;
            /// <summary>
            /// �����R�[�h 
            /// </summary>
            internal const int TORICD = 3;
            /// <summary>
            /// ��Ж� 
            /// </summary>
            internal const int KAINM = 4;
            /// <summary>
            /// ���������R�[�h 
            /// </summary>
            internal const int SEIBUCD = 5;
            /// <summary>
            /// �����N���� 
            /// </summary>
            internal const int SEIYYMM = 6;
            /// <summary>
            /// �������ԍ� 
            /// </summary>
            internal const int SEINO = 7;
            /// <summary>
            /// ���e�敪  
            /// </summary>
            internal const int NAIYOKBN = 8;
            /// <summary>
            /// �������s�ԍ� 
            /// </summary>
            internal const int SEIGYONO = 9;
            /// <summary>
            /// �l���s�敪 
            /// </summary>
            internal const int NEBIKBN = 10;
            /// <summary>
            /// �x���� 
            /// </summary>
            internal const int PAYDAY = 11;
            /// <summary>
            /// ���i�敪 
            /// </summary>
            internal const int SYOHINKBN = 12;
            /// <summary>
            /// ���i�敪���� 
            /// </summary>
            internal const int SYOHINKBNNM = 13;
            /// <summary>
            /// �E�v�R�[�h 
            /// </summary>
            internal const int TEKIYOCD = 15;
            /// <summary>
            /// �}�̃R�[�h 
            /// </summary>
            internal const int BAITAICD = 16;
            /// <summary>
            /// ���f�B�A�R�[�h 
            /// </summary>
            internal const int MEDIACD = 17;
            /// <summary>
            /// �`�ԋ敪�R�[�h 
            /// </summary>
            internal const int KEITAIKBNCD = 20;
            /// <summary>
            /// �`�ԋ敪���� 
            /// </summary>
            internal const int KEITAIKBNNM = 21;
            /// <summary>
            /// CM�b����1 
            /// </summary>
            internal const int CMNAME1 = 22;
            /// <summary>
            /// CM�b����2 
            /// </summary>
            internal const int CMNAME2 = 23;
            /// <summary>
            /// CM�b����3 
            /// </summary>
            internal const int CMNAME3 = 24;
            /// <summary>
            /// CM�b����4 
            /// </summary>
            internal const int CMNAME4 = 25;
            /// <summary>
            /// ���e����1 
            /// </summary>
            internal const int NAIYONAME1 = 26;
            /// <summary>
            /// ���e����2 
            /// </summary>
            internal const int NAIYONAME2 = 27;
            /// <summary>
            /// ���e����3 
            /// </summary>
            internal const int NAIYONAME3 = 28;
            /// <summary>
            /// ���e����4 
            /// </summary>
            internal const int NAIYONAME4 = 29;
            /// <summary>
            /// �ԑg����1 
            /// </summary>
            internal const int BNGMNAME1 = 30;
            /// <summary>
            /// �ԑg����2 
            /// </summary>
            internal const int BNGMNAME2 = 31;
            /// <summary>
            /// �ԑg����3 
            /// </summary>
            internal const int BNGMNAME3 = 32;
            /// <summary>
            /// �ԑg����4 
            /// </summary>
            internal const int BNGMNAME4 = 33;
            /// <summary>
            /// �f�ڏꏊ�R�[�h 
            /// </summary>
            internal const int KEISAIBASCD = 34;
            /// <summary>
            /// �f�ڏꏊ���� 
            /// </summary>
            internal const int KEISAIBASNM = 35;
            /// <summary>
            /// ���1�R�[�h 
            /// </summary>
            internal const int SYBT1CD = 36;
            /// <summary>
            /// ���1���� 
            /// </summary>
            internal const int SYBT1NM = 37;
            /// <summary>
            /// ���2�R�[�h 
            /// </summary>
            internal const int SYBT2CD = 38;
            /// <summary>
            /// ���2���� 
            /// </summary>
            internal const int SYBT2NM = 39;
            /// <summary>
            /// �F���R�[�h 
            /// </summary>
            internal const int SISACD = 40;
            /// <summary>
            /// �F������ 
            /// </summary>
            internal const int SISANM = 41;
            /// <summary>
            /// �T�C�Y�R�[�h 
            /// </summary>
            internal const int SIZECD = 42;
            /// <summary>
            /// �T�C�Y���� 
            /// </summary>
            internal const int SIZENM = 43;
            /// <summary>
            /// ��ʌf�ڃR�[�h 
            /// </summary>
            internal const int KOTUKEICD = 44;
            /// <summary>
            /// ��ʌf�ږ��� 
            /// </summary>
            internal const int KOTUKEINM = 45;
            /// <summary>
            /// ���� 
            /// </summary>
            internal const int KIKAN = 46;
            /// <summary>
            /// ���z 
            /// </summary>
            internal const int KINGAK = 51;
            /// <summary>
            /// ����� 
            /// </summary>
            internal const int SYOHIZEI = 52;
            /// <summary>
            /// ����� 
            /// </summary>
            internal const int ANBUNSYBT = 54;
            /// <summary>
            /// �����敪�� 
            /// </summary>
            internal const int SHORIKBNNM = 59;
            /// <summary>
            /// �o�^�N���� 
            /// </summary>
            internal const int TOUDATE = 60;
            /// <summary>
            /// ��No 
            /// </summary>
            internal const int JYUTNO = 64;
            /// <summary>
            /// �󒍖���No 
            /// </summary>
            internal const int JYMEINO = 65;
            /// <summary>
            /// ���㖾��No 
            /// </summary>
            internal const int URMEINO = 66;
            /// <summary>
            /// �A�� 
            /// </summary>
            internal const int RENBAN = 67;
        }

        /// <summary>
        /// �����f�[�^�o�͕����񒷍\���� 
        /// </summary>
        private struct ClaimDataItemLength
        {
            /// <summary>
            /// �˗��ԍ� 
            /// </summary>
            internal const int IRAINO = 8;
            /// <summary>
            /// �˗��s�ԍ�  
            /// </summary>
            internal const int IRAIGYONO = 4;
            /// <summary>
            /// �����R�[�h 
            /// </summary>
            internal const int TORICD = 7;
            /// <summary>
            /// ��Ж� 
            /// </summary>
            internal const int KAINM = 20;
            /// <summary>
            /// ���������R�[�h 
            /// </summary>
            internal const int SEIBUCD = 5;
            /// <summary>
            /// ���㕔���R�[�h 
            /// </summary>
            internal const int URIBUCD = 5;
            /// <summary>
            /// �����N���� 
            /// </summary>
            internal const int SEIYYMM = 8;
            /// <summary>
            /// �������ԍ� 
            /// </summary>
            internal const int SEINO = 8;
            /// <summary>
            /// ���e�敪 
            /// </summary>
            internal const int NAIYOKBN = 1;
            /// <summary>
            /// �l���s�敪 
            /// </summary>
            internal const int NEBIKBN = 1;
            /// <summary>
            /// �������s�ԍ� 
            /// </summary>
            internal const int SEIGYONO = 4;
            /// <summary>
            /// �x���� 
            /// </summary>
            internal const int PAYDAY = 8;
            /// <summary>
            /// �ېŋ敪 
            /// </summary>
            internal const int KAZEIKBN = 1;
            /// <summary>
            /// ����敪 
            /// </summary>
            internal const int URIKBN = 1;
            /// <summary>
            /// ����敪���� 
            /// </summary>
            internal const int URIKBNNM = 16;
            /// <summary>
            /// ���i�敪 
            /// </summary>
            internal const int SYOHINKBN = 3;
            /// <summary>
            /// ���i�敪���� 
            /// </summary>
            internal const int SYOHINKBNNM = 16;
            /// <summary>
            /// �E�v�R�[�h 
            /// </summary>
            internal const int TEKIYOCD = 5;
            /// <summary>
            /// �}�̃R�[�h 
            /// </summary>
            internal const int BAITAICD = 2;
            /// <summary>
            /// ���f�B�A�R�[�h 
            /// </summary>
            internal const int MEDIACD = 6;
            /// <summary>
            /// �n�敔���R�[�h 
            /// </summary>
            internal const int TIKBUSCD = 5;
            /// <summary>
            /// �X�� 
            /// </summary>
            internal const int TENBAN = 5;
            /// <summary>
            /// ���׃R�[�h�P 
            /// </summary>
            internal const int MEISAICD1 = 5;
            /// <summary>
            /// ���ז��̂P 
            /// </summary>
            internal const int MEISAINM1 = 20;
            /// <summary>
            /// ���׃R�[�h�Q 
            /// </summary>
            internal const int MEISAICD2 = 5;
            /// <summary>
            /// ���ז��̂Q 
            /// </summary>
            internal const int MEISAINM2 = 20;
            /// <summary>
            /// ���׃R�[�h�R 
            /// </summary>
            internal const int MEISAICD3 = 5;
            /// <summary>
            /// ���ז��̂R 
            /// </summary>
            internal const int MEISAINM3 = 20;
            /// <summary>
            /// ���׃R�[�h�S 
            /// </summary>
            internal const int MEISAICD4 = 5;
            /// <summary>
            /// ���ז��̂S 
            /// </summary>
            internal const int MEISAINM4 = 20;
            /// <summary>
            /// ���׃R�[�h�T 
            /// </summary>
            internal const int MEISAICD5 = 5;
            /// <summary>
            /// ���ז��̂T 
            /// </summary>
            internal const int MEISAINM5 = 20;
            /// <summary>
            /// ���׃R�[�h�U 
            /// </summary>
            internal const int MEISAICD6 = 5;
            /// <summary>
            /// ���ז��̂U 
            /// </summary>
            internal const int MEISAINM6 = 20;
            /// <summary>
            /// ���׃R�[�h�V 
            /// </summary>
            internal const int MEISAICD7 = 5;
            /// <summary>
            /// ���ז��̂V 
            /// </summary>
            internal const int MEISAINM7 = 20;
            /// <summary>
            /// ���׃R�[�h�W 
            /// </summary>
            internal const int MEISAICD8 = 5;
            /// <summary>
            /// ���ז��̂W 
            /// </summary>
            internal const int MEISAINM8 = 20;
            /// <summary>
            /// ���׃R�[�h�X 
            /// </summary>
            internal const int MEISAICD9 = 5;
            /// <summary>
            /// ���ז��̂X 
            /// </summary>
            internal const int MEISAINM9 = 20;
            /// <summary>
            /// ���׃R�[�h�P�O 
            /// </summary>
            internal const int MEISAICD10 = 5;
            /// <summary>
            /// ���ז��̂P�O 
            /// </summary>
            internal const int MEISAINM10 = 20;
            /// <summary>
            /// ���ז��̂P�P 
            /// </summary>
            internal const int MEISAINM11 = 4;
            /// <summary>
            /// ���ז��̂P�Q 
            /// </summary>
            internal const int MEISAINM12 = 20;
            /// <summary>
            /// ���ז��̂P�R 
            /// </summary>
            internal const int MEISAINM13 = 20;
            /// <summary>
            /// ���ז��̂P�S 
            /// </summary>
            internal const int MEISAINM14 = 60;
            /// <summary>
            /// ���ז��̂P�T 
            /// </summary>
            internal const int MEISAINM15 = 50;
            /// <summary>
            /// ���ז��̂P�U 
            /// </summary>
            internal const int MEISAINM16 = 50;
            /// <summary>
            /// ���ז��̂P�V 
            /// </summary>
            internal const int MEISAINM17 = 66;
            /// <summary>
            /// ���ז��̂P�W 
            /// </summary>
            internal const int MEISAINM18 = 3;
            /// <summary>
            /// ���ז��̂P�X 
            /// </summary>
            internal const int MEISAINM19 = 12;
            /// <summary>
            /// ���ז��̂Q�O 
            /// </summary>
            internal const int MEISAINM20 = 10;
            /// <summary>
            /// ���ז��̂Q�P 
            /// </summary>
            internal const int MEISAINM21 = 12;
            /// <summary>
            /// ���ז��̂Q�Q 
            /// </summary>
            internal const int MEISAINM22 = 13;
            /// <summary>
            /// ���ז��̂Q�R 
            /// </summary>
            internal const int MEISAINM23 = 60;
            /// <summary>
            /// ���ז��̂Q�S 
            /// </summary>
            internal const int MEISAINM24 = 60;
            /// <summary>
            /// ���ז��̂Q�T 
            /// </summary>
            internal const int MEISAINM25 = 60;
            /// <summary>
            /// ���� 
            /// </summary>
            internal const int SURYO = 13;
            /// <summary>
            /// �P�� 
            /// </summary>
            internal const int KEISAITNK = 13;
            /// <summary>
            /// ���z 
            /// </summary>
            internal const int KINGAK = 14;
            /// <summary>
            /// ����� 
            /// </summary>
            internal const int SYOHIZEI = 14;
            /// <summary>
            /// JLA���v���z 
            /// </summary>
            internal const int GOUKEI = 14;
            /// <summary>
            /// �����敪 
            /// </summary>
            internal const int SHORIKBN = 1;
            /// <summary>
            /// �����ԍ� 
            /// </summary>
            internal const int SHORINO = 8;
            /// <summary>
            /// ����� 
            /// </summary>
            internal const int ANBUNSYBT = 1;
            /// <summary>
            /// ���p�^�[�� 
            /// </summary>
            internal const int ANBUNPATTERN = 3;
            /// <summary>
            /// ���͏����敪 
            /// </summary>
            internal const int INSHORIKBN = 1;
            /// <summary>
            /// �v���O�����h�c 
            /// </summary>
            internal const int PRGID = 8;
            /// <summary>
            /// �[���h�c 
            /// </summary>
            internal const int PCID = 8;
            /// <summary>
            /// ���͕����R�[�h 
            /// </summary>
            internal const int INBUSCD = 5;
            /// <summary>
            /// ���͒S���҃R�[�h 
            /// </summary>
            internal const int INUSERCD = 7;
            /// <summary>
            /// ���͔N�� 
            /// </summary>
            internal const int INYYMM = 8;
            /// <summary>
            /// ���͎��� 
            /// </summary>
            internal const int INTIME = 6;
            /// <summary>
            /// �o�^�N���� 
            /// </summary>
            internal const int TOUDATE = 8;
            /// <summary>
            /// �ύX�N���� 
            /// </summary>
            internal const int HENDATE = 8;
            /// <summary>
            /// ����N���� 
            /// </summary>
            internal const int TORDATE = 8;
            /// <summary>
            /// �o�͓��� 
            /// </summary>
            internal const int OUTDATE = 40;
        }

        private class CheckException : Exception
        {
            private int m_index;

            public int Index
            {
                set{ m_index = value; }
                get{ return m_index; }
            }

            private int m_type;

            public int Type
            {
                set{ m_type = value; }
                get{ return m_type; }
            }

            public CheckException(int index, int type)
            {
                Index = index;

                Type = type;
            }
        };

        #endregion �\���� 

        #region �����o�ϐ� 

        /// <summary>
        /// Rg�i�r�p�����[�^ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
 
        /// <summary>
        /// �����N�� 
        /// </summary>
        private string _yyyyMM;

        /// <summary>
        /// �I���s 
        /// </summary>
        private int _row = 0;

        /// <summary>
        /// �ҏW�O�̐��������s�� 
        /// </summary>
        private string _beforeSeiYymm = string.Empty;
        
        /// <summary>
        /// �ҏW�O�̐������ԍ� 
        /// </summary>
        private string _beforeSeiSeiNo = string.Empty;

        /// <summary>
        /// �ҏW�O�̔����ԍ� 
        /// </summary>
        private string _beforeHatyuNo = string.Empty;

        /// <summary>
        /// �ҏW�O�̌������Ɏ擾�����f�[�^ 
        /// </summary>
        private ClaimDSAcom.ClaimNoDataRow _beforeRow;

        /// <summary>
        /// �ێ��p
        /// </summary>
        ClaimDSAcom HokanDs = new ClaimDSAcom();

        #endregion �����o�ϐ�

        #region �R���X�g���N�^ 

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public ClaimForm()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^ 

        #region �C�x���g 

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B 
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void ClaimForm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[��Load�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
//      private void ClaimForm_Load(object sender, EventArgs e)
        private void ClaimForm_Shown(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        /// <summary>
        /// �t�H�[��Resize�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClaimForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.tabControl1.ItemSize =
                    new Size(this.tabControl1.Width / this.tabControl1.TabCount - 1
                           , this.tabControl1.ItemSize.Height);
            }
        }

        /// <summary>
        /// �`�F�b�N�{�b�N�XCheckedChanged�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = null;

            // �I�����ꂽ���e�ɂ�荀�ڂ̕\���A��\����ݒ肷�� 
            if (sender.GetType() == this.chkShin.GetType())
            {
                chk = (CheckBox)sender;

                if (this.chkShin.Name.Equals(chk.Name))
                {
                    #region �V��

                    if (chk.Checked == true)
                    {
                        // ����/�����ԍ� ���وꗗ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASCD].Visible = true;      // �f�ڏꏊ�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASNM].Visible = true;      // �f�ڏꏊ���� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1CD].Visible = true;          // ���1�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1NM].Visible = true;          // ���1���� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2CD].Visible = true;          // ���2�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2NM].Visible = true;          // ���2���� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = true;           // �F���R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = true;           // �F������ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = true;          // �X�y�[�X�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = true;           // �T�C�Y���� 

                        // �����f�[�^ �ꗗ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASCD].Visible = true;              // �f�ڏꏊ�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASNM].Visible = true;              // �f�ڏꏊ���� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1CD].Visible = true;                  // ���1�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1NM].Visible = true;                  // ���1���� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2CD].Visible = true;                  // ���2�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2NM].Visible = true;                  // ���2���� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = true;                   // �F���R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = true;                   // �F������ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = true;                   // �T�C�Y�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = true;                   // �T�C�Y���� 
                    }
                    else
                    {
                        // ����/�����ԍ� ���وꗗ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASCD].Visible = false;     // �f�ڏꏊ�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASNM].Visible = false;     // �f�ڏꏊ���� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1CD].Visible = false;         // ���1�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1NM].Visible = false;         // ���1���� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2CD].Visible = false;         // ���2�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2NM].Visible = false;         // ���2���� 

                        //�G����OFF�̏ꍇ 
                        if (this.chkZashi.Checked == false)
                        {
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = false;          // �F���R�[�h 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = false;          // �F������ 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = false;          // �T�C�Y�R�[�h 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = false;          // �T�C�Y���� 
                        }
                        // �����f�[�^ �ꗗ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASCD].Visible = false;             // �f�ڏꏊ�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASNM].Visible = false;             // �f�ڏꏊ���� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1CD].Visible = false;                 // ���1�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1NM].Visible = false;                 // ���1���� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2CD].Visible = false;                 // ���2�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2NM].Visible = false;                 // ���2���� 
                        //�G����OFF�̏ꍇ 
                        if (this.chkZashi.Checked == false)
                        {
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = false;                  // �F���R�[�h 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = false;                  // �F������ 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = false;                  // �T�C�Y�R�[�h 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = false;                  // �T�C�Y���� 
                        }
                    }

                    #endregion �V��
                }

                if (this.chkZashi.Name.Equals(chk.Name))
                {
                    #region �G�� 

                    if (chk.Checked == true)
                    {
                        // ����/�����ԍ� ���وꗗ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = true;           // �F���R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = true;           // �F������ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = true;           // �T�C�Y�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = true;           // �T�C�Y���� 

                        // �����f�[�^ �ꗗ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = true;                   // �F���R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = true;                   // �F������ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = true;                   // �T�C�Y�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = true;                   // �T�C�Y���� 
                    }
                    else
                    {
                        //�V����OFF�̏ꍇ 
                        if (this.chkShin.Checked == false)
                        {
                            // ����/�����ԍ� ���وꗗ 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = false;          // �F���R�[�h 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = false;          // �F������ 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = false;          // �T�C�Y�R�[�h 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = false;          // �T�C�Y���� 
                            // �����f�[�^ �ꗗ 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = false;                  // �F���R�[�h 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = false;                  // �F������ 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = false;                  // �T�C�Y�R�[�h 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = false;                  // �T�C�Y���� 
                        }
                    }

                    #endregion �G�� 
                }

                if (this.chkDenpa.Name.Equals(chk.Name))
                {
                    #region �d�g 

                    if (chk.Checked == true)
                    {
                        // ����/�����ԍ� ���وꗗ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNCD].Visible = true;      // �`�ԋ敪�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNNM].Visible = true;      // �`�ԋ敪���� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME1].Visible = true;          // CM�b����1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME2].Visible = true;          // CM�b����2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME3].Visible = true;          // CM�b����3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME4].Visible = true;          // CM�b����4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME1].Visible = true;       // ���e����1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME2].Visible = true;       // ���e����2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME3].Visible = true;       // ���e����3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME4].Visible = true;       // ���e����4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME1].Visible = true;        // �ԑg��1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME2].Visible = true;        // �ԑg��2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME3].Visible = true;        // �ԑg��3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME4].Visible = true;        // �ԑg��4 

                        // �����f�[�^ �ꗗ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNCD].Visible = true;              // �`�ԋ敪�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNNM].Visible = true;              // �`�ԋ敪���� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME1].Visible = true;                  // CM�b����1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME2].Visible = true;                  // CM�b����2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME3].Visible = true;                  // CM�b����3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME4].Visible = true;                  // CM�b����4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME1].Visible = true;               // ���e����1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME2].Visible = true;               // ���e����2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME3].Visible = true;               // ���e����3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME4].Visible = true;               // ���e����4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME1].Visible = true;                // �ԑg��1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME2].Visible = true;                // �ԑg��2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME3].Visible = true;                // �ԑg��3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME4].Visible = true;                // �ԑg��4 
                    }
                    else
                    {
                        // ����/�����ԍ� ���وꗗ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNCD].Visible = false;     // �`�ԋ敪�R�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNNM].Visible = false;     // �`�ԋ敪���� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME1].Visible = false;         // CM�b����1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME2].Visible = false;         // CM�b����2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME3].Visible = false;         // CM�b����3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME4].Visible = false;         // CM�b����4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME1].Visible = false;      // ���e����1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME2].Visible = false;      // ���e����2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME3].Visible = false;      // ���e����3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME4].Visible = false;      // ���e����4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME1].Visible = false;       // �ԑg��1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME2].Visible = false;       // �ԑg��2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME3].Visible = false;       // �ԑg��3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME4].Visible = false;       // �ԑg��4 

                        // �����f�[�^ �ꗗ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNCD].Visible = false;             // �`�ԋ敪�R�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNNM].Visible = false;             // �`�ԋ敪���� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME1].Visible = false;                 // CM�b����1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME2].Visible = false;                 // CM�b����2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME3].Visible = false;                 // CM�b����3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME4].Visible = false;                 // CM�b����4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME1].Visible = false;              // ���e����1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME2].Visible = false;              // ���e����2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME3].Visible = false;              // ���e����3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME4].Visible = false;              // ���e����4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME1].Visible = false;               // �ԑg��1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME2].Visible = false;               // �ԑg��2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME3].Visible = false;               // �ԑg��3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME4].Visible = false;               // �ԑg��4 
                    }

                    #endregion �d�g 
                }

                if (this.chkKotsu.Name.Equals(chk.Name))
                {
                    #region ��� 

                    if (this.chkKotsu.Checked == true)
                    {
                        // ����/�����ԍ� ���وꗗ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEICD].Visible = true;        // ��ʌf�ڃR�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEINM].Visible = true;        // ��ʌf�ږ��� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KIKAN].Visible = true;            // ���� 

                        // �����f�[�^ �ꗗ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEICD].Visible = true;                // ��ʌf�ڃR�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEINM].Visible = true;                // ��ʌf�ږ��� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KIKAN].Visible = true;                    // ���� 
                    }
                    else
                    {
                        // ����/�����ԍ� ���وꗗ 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEICD].Visible = false;       // ��ʌf�ڃR�[�h 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEINM].Visible = false;       // ��ʌf�ږ��� 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KIKAN].Visible = false;           // ���� 

                        // �����f�[�^ �ꗗ 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEICD].Visible = false;               // ��ʌf�ڃR�[�h 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEINM].Visible = false;               // ��ʌf�ږ��� 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KIKAN].Visible = false;                   // ���� 
                    }

                    #endregion ��� 
                }
            }

        }

        /// <summary>
        /// �{�^��MouseMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// �{�^��MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            tslCnt.Text = String.Empty;
        }

        /// <summary>
        /// �����{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            BtnSrcClick();

            this.ActiveControl = null;
        }

        /// <summary>
        /// �o�̓{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click(object sender, EventArgs e)
        {
            BtnOutClick();

            this.ActiveControl = null;
        }

        /// <summary>
        /// �w���v�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Claim, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        /// <summary>
        /// �߂�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParameter, true);
        }

        /// <summary>
        /// ���׃X�v���b�h�̃Z���Ƀt�H�[�J�X���ړ�����Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_EnterCell(object sender, EnterCellEventArgs e)
        {
            _row = e.Row;
            _beforeSeiYymm = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEIYYMM].Value);
            _beforeSeiSeiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEINO].Value);
        }

        /// <summary>
        /// ���׃X�v���b�h�̕ҏW���[�h���J�n����Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_EditModeOn(object sender, EventArgs e)
        {
            _row = spdClaimNo_Sheet1.ActiveRow.Index;
            //_beforeSeiYymm = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEIYYMM].Value);
            //_beforeHatyuNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.IRAINO].Value);
            //_beforeSeiSeiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEINO].Value);

            _beforeRow = (ClaimDSAcom.ClaimNoDataRow)HokanDs.ClaimNoData.Rows[_row];

            // ���͐���̗L����
            InputControlOn( spdClaimNo_Sheet1.ActiveColumn.Index );
        }

        /// <summary>
        /// ���׃X�v���b�h�̕ҏW���[�h���I������Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_EditModeOff(object sender, EventArgs e)
        {
            // ���͐���̖�����
            InputControlOff( spdClaimNo_Sheet1.ActiveColumn.Index );

            // �ҏW���ꂽ�s�̍��ڎ擾 
            // �����ԍ� 
            string iraiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.IRAINO].Value);
            // �������ԍ� 
            string seiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEINO].Value);
            // �o�͓��� 
            string outDate = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.OUTDATE].Value);
            // ���������s�� 
            string seiYymm = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEIYYMM].Value);

            int seiGyoNo = 1;

            //�ύX���ꂽ�s���擾����
            ClaimDSAcom.ClaimDataRow[] SelectDataRow = (ClaimDSAcom.ClaimDataRow[])HokanDs.ClaimData.Select("iraiNo = '" + _beforeRow.iraiNo + "' AND seiNo = '" + _beforeRow.seiNo + "' ");
            ClaimDSAcom.ClaimDiffDataRow[] SelectDiffRow = (ClaimDSAcom.ClaimDiffDataRow[])HokanDs.ClaimDiffData.Select("iraiNo = '" + _beforeRow.iraiNo + "' AND seiNo = '" + _beforeRow.seiNo + "' ");


            //foreach (ClaimDSAcom.ClaimDataRow row in HokanDs.ClaimData)
            //{
            //    if (row.iraiNo.Trim().Equals(_beforeRow.iraiNo.Trim()))
            //    {

            //    }
            //}

            //List<string> list = new List<string>();

            //foreach (ClaimDSAcom.ClaimDataRow row in HokanDs.ClaimData.Rows)
            //{
            //    if (row.iraiNo.Equals(_beforeRow.iraiNo) && row.seiNo.Equals(_beforeRow.seiNo))
            //    {
            //        //�C���f�b�N�X�𒸂�����B
            //        list.Add(HokanDs.ClaimData.Rows.IndexOf(row).ToString());
            //    }
            //}


            List<ClaimDSAcom.ClaimDataRow> sprRow = new List<ClaimDSAcom.ClaimDataRow>();
            //ClaimDSAcom.ClaimDataRow[] sprRow = new ClaimDSAcom.ClaimDataRow[SelectDataRow.Length];
            foreach (ClaimDSAcom.ClaimDataRow row in SelectDataRow)
            {
                
                //_dsClaim.ClaimData.Rows[HokanDs.ClaimData.Rows.IndexOf(row)]
                
                // ���������s����ݒ肷��
                spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SEIYYMM].Value = seiYymm;

                //�������ԍ���ݒ肷�� 
                spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SEINO].Value = seiNo;

                if (SYBT_S.Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SYBT].Value)))
                {
                    // �������s�ԍ� 
                    spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SEIGYONO].Value = seiGyoNo.ToString("000");
                    seiGyoNo += 1;
                }

                sprRow.Add((ClaimDSAcom.ClaimDataRow)_dsClaim.ClaimData.Rows[HokanDs.ClaimData.Rows.IndexOf(row)]);

            }

            _dsClaim.ClaimData.AcceptChanges();

            
            


            //foreach (ClaimDSAcom.ClaimDataRow _dsrow in _dsClaim.ClaimData.Rows)
            //{


            //    foreach (ClaimDSAcom.ClaimDataRow SelRow in SelectRow)
            //    {
            //        if ()
            //        {

            //        }
            //    }



            //}

            // �����f�[�^�ꗗ�֔��f 
            //foreach (Row row in spdClaim_Sheet1.Rows)
            //{
                //if (iraiNo.Trim().Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.IRAINO].Value).Trim()))
                //{

                


                        // ���������s����ݒ肷��  
                        //spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIYYMM].Value = seiYymm;
                    


                        // �������ԍ���ݒ肷�� 
                        //spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value = seiNo;

                        // ��ʂ��uS�v�̏ꍇ�ɐ������s�ԍ���ݒ肷�� 
                        //if (SYBT_S.Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYBT].Value)))
                        //{
                        //    // �������s�ԍ� 
                        //    spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIGYONO].Value = seiGyoNo.ToString("000");
                        //    seiGyoNo += 1;
                        //}

                //}
            //}

            foreach (ClaimDSAcom.ClaimDiffDataRow row in SelectDiffRow)
            {

                // ���������s����ݒ肷�� 
                spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimDiffListColNo.SEIYYMM].Value = seiYymm;
                // �������ԍ���ݒ肷�� 
                spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimDiffListColNo.SEINO].Value = seiNo;



                foreach (ClaimDSAcom.ClaimDataRow row1 in SelectDataRow)
                {
                    if (row.iraiNo.Equals(row1.iraiNo) && row.seiNo.Equals(row1.seiNo) && row.iraiGyoNo.Equals(row1.iraiGyoNo))
                    {
                        ClaimDSAcom.ClaimDataRow srow = (ClaimDSAcom.ClaimDataRow)_dsClaim.ClaimData.Rows[HokanDs.ClaimData.Rows.IndexOf(row1)];

                        if (SYBT_S.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimListColNo.SYBT].Value)))
                        {
                            //�������s�ԍ�
                            spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimListColNo.SEIGYONO].Value = srow.seiGyoNo.Trim();
                        }
                        break;
                    }
                }





            }

            _dsClaim.ClaimDiffData.AcceptChanges();








            // ���وꗗ�֔��f 
            //foreach (Row row in spdClaimDiff_Sheet1.Rows)
            //{
            //    // ��ʂ��uS�v�̏ꍇ�ɐ������s�ԍ���ݒ肷�� 
            //    if (SYBT_S.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SYBT].Value).Trim()))
            //    {
            //        if (iraiNo.Trim().Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.IRAINO].Value).Trim()))
            //        {
            //            // �ҏW�O�̒l�Ɠ����ꍇ�̂݁A 
            //            if (_beforeSeiYymm.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEIYYMM].Value)))
            //            {
            //                // ���������s����ݒ肷�� 
            //                spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEIYYMM].Value = seiYymm;
            //            }

            //            // �ҏW�O�̒l�Ɠ����ꍇ�̂݁A 
            //            if (_beforeSeiSeiNo.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEINO].Value)))
            //            {
            //                // �������ԍ���ݒ肷�� 
            //                spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEINO].Value = seiNo;
            //            }

            //            foreach (Row row2 in spdClaim_Sheet1.Rows)
            //            {
            //                if (!SYBT_S.Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.SYBT].Value)))
            //                {
            //                    continue;
            //                }

            //                String claimDiff_IRAINO    = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.IRAINO].Value).Trim();
            //                String claimDiff_IRAIGYONO = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.IRAIGYONO].Value).Trim();
            //                String claimDiff_SEINO     = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEINO].Value).Trim();

            //                String claim_IRAINO        = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.IRAINO].Value).Trim();
            //                String claim_IRAIGYONO     = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.IRAIGYONO].Value).Trim();
            //                String claim_SEINO         = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.SEINO].Value).Trim();

            //                if
            //                (
            //                    ( claimDiff_IRAINO    != claim_IRAINO    ) ||
            //                    ( claimDiff_IRAIGYONO != claim_IRAIGYONO ) ||
            //                    ( claimDiff_SEINO     != claim_SEINO     )
            //                )
            //                {
            //                    continue;
            //                }

            //                String seiGyoNo2 = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.SEIGYONO].Value).Trim();

            //                // �������s�ԍ� 
            //                spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEIGYONO].Value = seiGyoNo2;

            //                break;
            //            }
            //        }
            //    }
            //}

        }

        /// <summary>
        /// �Z�����Ń}�E�X�̃{�^�����Q�񉟂��Ƃ��ɔ������܂��i�_�u���N���b�N�j 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            // �o�͑I���ŁA��w�b�_�̏ꍇ 
            if (e.Column == ClaimNoListColNo.OUTSELECT)
            {
                if (e.ColumnHeader)
                {
                    string value = "False";     // �o�͑I��l 

                    string outSelect =
                        KKHUtility.ToString(spdClaimNo_Sheet1.Cells[0, ClaimNoListColNo.OUTSELECT].Value);  // �o�͑I�� 

                    // �擪�s�̏o�͑I�����ڂ��A�`�F�b�N�n�m�̏ꍇ 
                    if ("True".Equals(outSelect))
                    {
                        // �S�Ẵ`�F�b�N�{�b�N�X���n�e�e�ɂ��� 
                        value = "False";
                    }
                    else
                    {
                        // �S�Ẵ`�F�b�N�{�b�N�X���`�F�b�N�n�m�ɂ��� 
                        value = "True";
                    }

                    foreach (Row row in spdClaimNo_Sheet1.Rows)
                    {
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.OUTSELECT].Value = value;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //[�o��]�{�^����񊈐��� 
            btnOut.Enabled = false;
        }

        #endregion �C�x���g 

        #region ���\�b�h 

        /// <summary>
        /// �e�R���g���[���̏����ݒ胁�\�b�h 
        /// </summary>
        private void InitializeControl()
        {
            // �N���R���g���[�� 
            string strDate = _naviParameter.strDate.Replace("/", string.Empty).Substring(0, 6);

            if (strDate != "")
            {
                strDate = strDate.Trim().Replace("/", "");
                if (strDate.Trim().Length >= 6)
                {
                    txtYm.Value = strDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = strDate;
                }
                txtYm.cmbYM_SetDate();
            }

            // �X�e�[�^�X�ݒ� 
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;

            // �o�̓{�^�� 
            btnOut.Enabled = false;

            //�X�v���b�h�̓��̓}�b�v�ݒ� 
            InputMap im = new InputMap();

            // ����/�����ԍ� �ꗗ 
            //��ҏW�Z���ł�[F2]�L�[�𖳌� 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //�ҏW���Z���ł�[F2]�L�[�𖳌� 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //��ҏW�Z���ł�[ESC]�L�[�𖳌� 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Escape , Keys.None), SpreadActions.None);
            //�ҏW���Z���ł�[ESC]�L�[�𖳌� 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), SpreadActions.None);

            // ����/���� ���وꗗ 
            //��ҏW�Z���ł�[F2]�L�[�𖳌� 
            im = spdClaimDiff.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //�ҏW���Z���ł�[F2]�L�[�𖳌� 
            im = spdClaimDiff.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // �����f�[�^ �ꗗ 
            //��ҏW�Z���ł�[F2]�L�[�𖳌� 
            im = spdClaim.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //�ҏW���Z���ł�[F2]�L�[�𖳌� 
            im = spdClaim.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
        }

        /// <summary>
        /// �I�����ꂽ�}�̎�ʂ̏�����ҏW���郁�\�b�h 
        /// </summary>
        /// <returns></returns>
        private string GetBaitaiSybtJoken()
        {
            StringBuilder ret = new StringBuilder();

            // �V�� 
            if (chkShin.Checked)
            {
                ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_SNBN + "'");
            }
            // �G�� 
            if (chkZashi.Checked)
            {
                if (!string.IsNullOrEmpty(ret.ToString()))
                {
                    ret.Append(", '" + KkhConstAcom.MediaKindCode.SYBT_ZASI + "'");
                }
                else
                {
                    ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_ZASI + "'");
                }
            }
            // �d�g 
            if (chkDenpa.Checked)
            {
                if (!string.IsNullOrEmpty(ret.ToString()))
                {
                    ret.Append(", '" + KkhConstAcom.MediaKindCode.SYBT_DENP + "'");
                }
                else
                {
                    ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_DENP + "'");
                }
            }
            // ��� 
            if (chkKotsu.Checked)
            {
                if (!string.IsNullOrEmpty(ret.ToString()))
                {
                    ret.Append(", '" + KkhConstAcom.MediaKindCode.SYBT_KOTU + "'");
                }
                else
                {
                    ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_KOTU + "'");
                }
            }

            return ret.ToString();
        }

        /// <summary>
        /// �����f�[�^�������\�b�h 
        /// </summary>
        /// <returns>�������ʌ���</returns> 
        private int FindReportData()
        {

            // �f�[�^�Z�b�g�N���A 
            _dsClaim.ClaimNoData.Clear();
            _dsClaim.ClaimData.Clear();
            _dsClaim.ClaimDiffData.Clear();
            _dsClaim.ClaimNoData.AcceptChanges();
            _dsClaim.ClaimData.AcceptChanges();
            _dsClaim.ClaimDiffData.AcceptChanges();

            // �����\���N���A 
            statusStrip1.Items["tslval1"].Text = string.Empty;

            ClaimAcomProcessController.FindClaimByCondParam param =
                new ClaimAcomProcessController.FindClaimByCondParam();

            // �p�����[�^�ݒ� 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYm.Value;
            // �}�̎�� 
            string sybt = this.GetBaitaiSybtJoken();
            if (string.IsNullOrEmpty(sybt))
            {
                // �}�̎�ʂ��I������Ă��Ȃ��ꍇ�͏I�� 
                return 0;
            }
            param.sybt = sybt;

            // �������̔N����ێ� 
            _yyyyMM = param.yymm;

            // �����f�[�^���� 
            ClaimAcomProcessController processController = ClaimAcomProcessController.GetInstance();
            FindClaimAcomByCondServiceResult result = processController.FindClaimByCond(param);

            if (result.HasError == true)
            {
                // �T�[�o�[����Ԃ��G���[������̃��b�Z�[�W�̏ꍇ
                if (result.MessageCode == MessageCode.HB_W0144)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0144, null, Text, MessageBoxButtons.OK);
                }

                return 0;
            }

            ////�ێ��p�Ɋi�[
            //HokanDs.Clear();
            //HokanDs.Merge(result.ClaimDataSet);
            //HokanDs.AcceptChanges();

            // ����/�����ԍ��ꗗ 
            _dsClaim.ClaimNoData.Merge(result.ClaimDataSet.ClaimNoData);
            _dsClaim.ClaimNoData.AcceptChanges();

            // �����f�[�^ �ꗗ 
            _dsClaim.ClaimData.Merge(result.ClaimDataSet.ClaimData);
            _dsClaim.ClaimData.AcceptChanges();

            // ����/�����ԍ� ���وꗗ 
            // ���ѕς����s���X�v���b�h�ɃZ�b�g���� 
            ClaimDSAcom.ClaimDiffDataDataTable dt = this.SetOrderForClaimDiff(result.ClaimDataSet.ClaimDiffData);
            _dsClaim.ClaimDiffData.Merge(dt);
            _dsClaim.ClaimDiffData.AcceptChanges();


            if (result.ClaimDataSet.ClaimData.Rows.Count == 0)
            {
                // �f�[�^�����݂��Ȃ��ꍇ��0��Ԃ� 
                return 0;
            }
            
            return result.ClaimDataSet.ClaimData.Rows.Count;
        }

        /// <summary>
        /// ����/�����ԍ� ���وꗗ�̕��я���ݒ肷�郁�\�b�h 
        /// </summary>
        /// <param name="resultDt">����/�����ԍ� ���وꗗ���</param>
        /// <returns>���ѕς����s�����f�[�^�e�[�u��</returns>
        private ClaimDSAcom.ClaimDiffDataDataTable SetOrderForClaimDiff(ClaimDSAcom.ClaimDiffDataDataTable resultDt)
        {
            

            ClaimDSAcom.ClaimDiffDataDataTable dt = (ClaimDSAcom.ClaimDiffDataDataTable)resultDt;
            // �N���[���𐶐� 
            ClaimDSAcom.ClaimDiffDataDataTable newdt = (ClaimDSAcom.ClaimDiffDataDataTable)resultDt.Clone();

            // �\�[�g���s 
            ClaimDSAcom.ClaimDiffDataRow[] drs;
            drs = (ClaimDSAcom.ClaimDiffDataRow[])dt.Select(string.Empty, dt.sortNoColumn.ColumnName);
            foreach (ClaimDSAcom.ClaimDiffDataRow row in drs)
            {
                newdt.ImportRow(row);
            }

            return newdt;
        }

        /// <summary>
        /// ����/�����ԍ� ���وꗗ�̔w�i�F��ݒ肷�郁�\�b�h 
        /// </summary>
        private void SetBackColorForClaimDiff()
        {
            // �قȂ鍀�ڂ�����f�[�^�̔�����NO�Ɠ����f�[�^������ 
            foreach (Row row in spdClaimDiff_Sheet1.Rows)
            {
                // ��ʎ擾  
                string sybt = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SYBT].Value);

                if (SYBT_H.Equals(sybt))
                {
                    // �s�̔w�i�F��ݒ� 
                    spdClaimDiff_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_DGRAY;
                }

                // �ŏI�s�̏ꍇ�́A�ȍ~�̏������s��Ȃ� 
                if (row.Index == spdClaimDiff_Sheet1.RowCount - 1)
                {
                    break;
                }

                foreach (Column col in spdClaimDiff_Sheet1.Columns)
                {
                    // �f�[�^�擾 
                    string value = spdClaimDiff_Sheet1.Cells[row.Index, col.Index].Text;
                    // �f�[�^�擾�i��r�p�j 
                    string value2 = spdClaimDiff_Sheet1.Cells[row.Index + 1, col.Index].Text;

                    // ��ʂ̏ꍇ 
                    if (col.Index == ClaimDiffListColNo.SYBT)
                    {
                        // �ȉ��̏����̏ꍇ�Abreak���� 
                        if ((SYBT_S.Equals(value) && SYBT_S.Equals(value2)) ||
                            (SYBT_H.Equals(value) && SYBT_H.Equals(value2)) ||
                            (SYBT_S.Equals(value) && SYBT_H.Equals(value2)))
                        {
                            break;
                        }
                    }
                    // ���i�敪�̏ꍇ 
                    else if (col.Index == ClaimDiffListColNo.SYOHINKBN)
                    {
                        bool flg = false;

                        // NULL�A�󕶎��̏ꍇ 
                        if ((!string.IsNullOrEmpty(value) && string.IsNullOrEmpty(value2)) ||
                            (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value2)))
                        {
                            flg = true;
                        }
                        // �l������łȂ��ꍇ 
                        else if (!value.Substring(0, 2).Equals(value2.Substring(0, 2)))
                        {
                            flg = true;
                        }

                        if (flg)
                        {
                            // �قȂ鍀�ڂ����݂��郌�R�[�h��ʂ�Ԃ����� 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, col.Index].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;

                            // �قȂ鍀�ڂ����݂���ں��ގ�ʂ�Ԃ�����(���₷���悤�ɔ}�̎�ʂ�Ԃ�����) 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, ClaimDiffListColNo.SYBT].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;
                        }
                    }
                    // �����ԍ��A�����s�ԍ��A���e�敪�A�E�v�R�[�h�A 
                    // �}�̃R�[�h�A���f�B�A�R�[�h�A���z�A����ʂ̏ꍇ 
                    else if (col.Index == ClaimDiffListColNo.IRAINO ||
                             col.Index == ClaimDiffListColNo.IRAIGYONO ||
                             col.Index == ClaimDiffListColNo.NAIYOKBN ||
                             col.Index == ClaimDiffListColNo.TEKIYOCD ||
                             col.Index == ClaimDiffListColNo.BAITAICD ||
                             col.Index == ClaimDiffListColNo.MEDIACD ||
                             col.Index == ClaimDiffListColNo.KINGAK ||
                             col.Index == ClaimDiffListColNo.ANBUNSYBT)
                    {
                        // �l������łȂ��ꍇ 
                        if (!value.Equals(value2))
                        {
                            // �قȂ鍀�ڂ����݂��郌�R�[�h��ʂ�Ԃ����� 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, col.Index].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;

                            // �قȂ鍀�ڂ����݂���ں��ގ�ʂ�Ԃ�����(���₷���悤�ɔ}�̎�ʂ�Ԃ�����) 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, ClaimDiffListColNo.SYBT].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// �����f�[�^�ꗗ�̔w�i�F��ݒ肷�郁�\�b�h 
        /// </summary>
        /// <param name="shoriKbnDict">�����敪���X�g</param>
        private void SetBackColorForClaim(Dictionary<string, string> shoriKbnDict)
        {

            foreach (Row row in spdClaim_Sheet1.Rows)
            {
                // �������ԍ��擾 
                string seiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value);

                // �����̏����敪���X�g�ɑ��݂���ꍇ 
                if (shoriKbnDict.ContainsKey(seiNo))
                {
                    // �w�i�F�A�����敪��ݒ肷�� 
                    if (ShoriKbnNm.MiSyutu.Equals(shoriKbnDict[seiNo]))
                    {
                        // ���o�� 
                        // �w�i�F��ݒ肷�� 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_WHITE;
                        // �����敪�ɒl��ݒ肷�� 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.MiSyutu;
                    }
                    else if (ShoriKbnNm.MiSoushin.Equals(shoriKbnDict[seiNo]))
                    {
                        // �����M 
                        // �w�i�F��ݒ肷�� 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_WHITE;
                        // �����敪�ɒl��ݒ肷�� 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.MiSoushin;
                    }
                    else if (ShoriKbnNm.SoushinZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // ���M�� 
                        // �w�i�F��ݒ肷�� 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_MROSE;
                        // �����敪�ɒl��ݒ肷�� 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.SoushinZumi;
                    }
                    else if (ShoriKbnNm.IchbuSyutuZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // �ꎞ���M�� 
                        // �w�i�F��ݒ肷�� 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LYELLOW;
                        // �����敪�ɒl��ݒ肷�� 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.IchbuSyutuZumi;
                    }
                }
            }

        }

        /// <summary>
        /// ����/�����ԍ� �ꗗ�̔w�i�F��ݒ肷�郁�\�b�h 
        /// </summary>
        /// <param name="shoriKbnDict">�����敪���X�g</param>
        private void SetBackColorForClaimNo(Dictionary<string, string> shoriKbnDict)
        {

            foreach (Row row in spdClaimNo_Sheet1.Rows)
            {
                // �������ԍ��擾 
                string seiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SEINO].Value);

                // �����̏����敪���X�g�ɑ��݂���ꍇ 
                if (shoriKbnDict.ContainsKey(seiNo))
                {
                    // �w�i�F�A�����敪�A�o�͑I����ݒ肷�� 
                    if (ShoriKbnNm.MiSyutu.Equals(shoriKbnDict[seiNo]))
                    {
                        // ���o�� 
                        // �w�i�F��ݒ肷�� 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_WHITE;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.MiSyutu;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.OUTSELECT].Value = "True";
                    }
                    else if (ShoriKbnNm.MiSoushin.Equals(shoriKbnDict[seiNo]))
                    {
                        // �����M 
                        // �w�i�F��ݒ肷�� 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_PBLUE;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.MiSoushin;
                    }
                    else if (ShoriKbnNm.SoushinZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // ���M�� 
                        // �w�i�F��ݒ肷�� 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_MROSE;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.SoushinZumi;
                    }
                    else if (ShoriKbnNm.IchbuSyutuZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // �ꎞ���M�� 
                        // �w�i�F��ݒ肷�� 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LYELLOW;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.IchbuSyutuZumi;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.OUTSELECT].Value = "True";
                    }
                }
            }

        }

        /// <summary>
        /// �����敪�̔��菈�����s�����\�b�h 
        /// </summary>
        /// <returns>��������</returns>
        private Dictionary<string, string> ShoriKbnCheck()
        {
            Dictionary<string, string> retDict = new Dictionary<string, string>();  // �����敪���X�g 
            string shoriKbnNm = ShoriKbnNm.MiSyutu;                                 // �����敪 

            foreach (Row row in spdClaimNo_Sheet1.Rows)
            {
                // �����敪�擾 
                string shoriKbn = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value);

                // �������ԍ��擾 
                string key = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SEINO].Value);

                // ���X�g�ɓ���̐������ԍ������݂���ꍇ 
                if (retDict.ContainsKey(key))
                {
                    // ���X�g��ҏW 
                    if (retDict[key].Equals(shoriKbnNm))
                    {
                        // ���X�g�ŕێ����Ă���l�Ɠ���̏ꍇ�A�l�����̂܂ܑ������ 
                        retDict[key] = shoriKbnNm;
                    }
                    else
                    {
                        // ���X�g�ŕێ����Ă���l�Ɠ���łȂ��ꍇ�A�u�ꕔ�o�͍ρv�Ƃ��� 
                        retDict[key] = ShoriKbnNm.IchbuSyutuZumi;
                    }
                }
                else
                {
                    // ���X�g�ɒǉ� 
                    retDict.Add(key, shoriKbn);
                }
            }

            return retDict;
        }

        /// <summary>
        /// �����f�[�^�o�̓`�F�b�N�i����/�����ԍ� �ꗗ�j���\�b�h 
        /// �E�`�F�b�N���S�Ăn�j�̏ꍇ�A�����̏o�͐������ԍ����X�g�ɁA 
        ///   ����/�����ԍ� �ꗗ�Ń`�F�b�N���ꂽ�������ԍ����Z�b�g���� 
        /// </summary>
        /// <param name="seiNoList">�o�͐������ԍ����X�g</param>
        /// <returns>��������</returns>
        private bool PutClimDataCheckClaimNo(out List<string> seiNoList)
        {
            seiNoList = new List<string>();    // �o�͐������ԍ����X�g 
            bool selFlg = false;               // �����ςݑI���t���O 

            for (int iRow = 0; iRow <= spdClaimNo_Sheet1.RowCount - 1; iRow++)
            {
                string shoriKbn =
                    KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow, ClaimNoListColNo.SHORIKBN].Value);   // �����敪 
                string outSelect =
                    KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow, ClaimNoListColNo.OUTSELECT].Value);  // �o�͑I�� 

                // �o�͑I�����I������Ă���ꍇ 
                if ("True".Equals(outSelect))
                {
                    string seiNo =
                        KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow, ClaimNoListColNo.SEINO].Value);      // �������ԍ� 

                    // �������ԍ��`�F�b�N -----------------------------------------------------------------------------
                    for (int iRow2 = iRow + 1; iRow2 < spdClaimNo_Sheet1.RowCount; iRow2++)
                    {
                        string seiNo2 =
                            KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow2, ClaimNoListColNo.SEINO].Value); // �������ԍ�(��r�p) 

                        // �������ԍ��Ɛ������ԍ�(��r�p)�������ꍇ�A���b�Z�[�W��\�����������I������ 
                        if (!string.IsNullOrEmpty(seiNo) &&
                            !string.IsNullOrEmpty(seiNo2) &&
                            seiNo.Equals(seiNo2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0112, null, this.Text, MessageBoxButtons.OK);
                            return false;
                        }
                    }

                    //// �������ԍ����̓`�F�b�N -------------------------------------------------------------------------
                    //if (string.IsNullOrEmpty(seiNo))
                    //{
                    //    MessageUtility.ShowMessageBox(MessageCode.HB_W0113, null, this.Text, MessageBoxButtons.OK);
                    //    return false;
                    //}

                    // �������ԍ������`�F�b�N -------------------------------------------------------------------------
                    if (seiNo.Length != 8)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0114, null, this.Text, MessageBoxButtons.OK);
                        return false;
                    }

                    // ���s�ɍ��킹�邽�߂ɂ����Č����`�F�b�N�̌��ōs��.

                    // �������ԍ����̓`�F�b�N -------------------------------------------------------------------------
                    if (string.IsNullOrEmpty(seiNo))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0113, null, this.Text, MessageBoxButtons.OK);
                        return false;
                    }

                    // �o�͑I���`�F�b�N -------------------------------------------------------------------------------
                    // �����M�Ƀ`�F�b�N�����Ă���ꍇ 
                    if (ShoriKbnNm.MiSoushin.Equals(shoriKbn))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0115, null, this.Text, MessageBoxButtons.OK);
                        return false;
                    }

                    // �o�͍ςɃ`�F�b�N�����Ă���ꍇ 
                    if (ShoriKbnNm.SoushinZumi.Equals(shoriKbn))
                    {
                        selFlg = true;
                    }

                    // �������ԍ������X�g�Ɋi�[ 
                    seiNoList.Add(seiNo);
                }
            }

            if (selFlg)
            {
                //���b�Z�[�W���o�� 
                if (DialogResult.No == MessageUtility.ShowMessageBox(MessageCode.HB_C0013, null, this.Text, MessageBoxButtons.YesNo))
                {
                    //�u�L�����Z���v�̏ꍇ�A�������I������ 
                    return false;
                }
            }

            // �o�͑I�����O���̏ꍇ�A���b�Z�[�W��\�����������I������ 
            if (seiNoList.Count == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0116, null, this.Text, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        /// <summary>
        /// �����f�[�^�o�̓`�F�b�N�i�����f�[�^ �ꗗ�j���\�b�h 
        /// </summary>
        /// <param name="seiNoList">�o�͐������ԍ����X�g</param>
        /// <returns>��������</returns>
        private bool PutClaimDataCheckClaim(List<string> seiNoList)
        {
            string seiNo = string.Empty;        // �������ԍ� 
            string saveSeiNo = string.Empty;    // �������ԍ� 
            string sybt = string.Empty;         // ��� 

            // �����f�[�^ �ꗗ�̓��͒l���`�F�b�N���� 
            foreach (Row row in spdClaim_Sheet1.Rows)
            {
                seiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value);  // �������ԍ�                
                sybt = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYBT].Value);    // ��� 

                if (!seiNoList.Contains(seiNo))
                {
                    // �ΏۊO�̃f�[�^�ׁ̈A�ǂݔ�΂� 
                    continue;
                }

                // �����R�[�h 
                string toriCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.TORICD].Value);
                if (string.IsNullOrEmpty(toriCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�����R�[�h"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // ��Ж� 
                string kaiNm = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.KAINM].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(kaiNm.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"��Ж�"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // ���������R�[�h 
                string seibuCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIBUCD].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(seibuCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"���������R�[�h"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �����N���� 
                string seiYymm = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIYYMM].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(seiYymm.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"���������s��"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }
                if (seiYymm.Length != 8 || !KKHUtility.IsDate(seiYymm, "yyyyMMdd"))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0118, new string[] {seiNo}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �������ԍ� 
                if (string.IsNullOrEmpty(seiNo.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�������ԍ�"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �������s�ԍ� 
                string seiGyoNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIGYONO].Value);
                if (!SYBT_T.Equals(sybt) && string.IsNullOrEmpty(seiGyoNo.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�������s�ԍ�"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �x���� 
                string payDay = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.PAYDAY].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(payDay.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�x����"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // ���i�敪 
                string syohinKbn = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYOHINKBN].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(syohinKbn.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"���i�敪"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // ���i�敪���� 
                string syohinKbnNm = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYOHINKBNNM].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(syohinKbnNm.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"���i�敪����"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �E�v�R�[�h 
                string tekiyoCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.TEKIYOCD].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(tekiyoCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�E�v�R�[�h"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �}�̃R�[�h 
                string baitaiCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.BAITAICD].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(baitaiCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�}�̃R�[�h"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // ���f�B�A�R�[�h 
                string mediaCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.MEDIACD].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(mediaCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"���f�B�A�R�[�h"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                if (!string.IsNullOrEmpty(saveSeiNo) && seiNo.Equals(saveSeiNo))
                {
                    // ���z 
                    decimal kingak = KKHUtility.DecParse(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.KINGAK].Text);
                    if (SYBT_H.Equals(sybt))
                    {
                        kingak = 0M;
                    }
                    if (kingak == 0M)
                    {
                        // ���b�Z�[�W���o�� 
                        if (DialogResult.Cancel == MessageUtility.ShowMessageBox(MessageCode.HB_C0012
                                                                                , new string[] { seiNo, "���z" }
                                                                                , this.Text
                                                                                , MessageBoxButtons.OKCancel))
                        {
                            //�u�L�����Z���v�̏ꍇ�A�������I������ 
                            return false;
                        }
                    }

                    // ����� 
                    decimal syohiZei = KKHUtility.DecParse(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYOHIZEI].Text);
                    if (SYBT_H.Equals(sybt))
                    {
                        syohiZei = 0M;
                    }
                    if (syohiZei == 0M)
                    {
                        // ���b�Z�[�W���o�� 
                        if (DialogResult.Cancel == MessageUtility.ShowMessageBox(MessageCode.HB_C0012
                                                                                , new string[] { seiNo, "�����" }
                                                                                , this.Text
                                                                                , MessageBoxButtons.OKCancel))
                        {
                            //�u�L�����Z���v�̏ꍇ�A�������I������ 
                            return false;
                        }
                    }
                }

                // ����� 
                string anbunSybt = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.ANBUNSYBT].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(anbunSybt.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�����"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �o�^�N���� 
                string touDate = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.TOUDATE].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(touDate.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"�o�^�N����"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // �������ԍ���ێ� 
                saveSeiNo = seiNo;
            }

            return true;
        }

        /// <summary>
        /// �����f�[�^�o�̓��\�b�h 
        /// </summary>
        /// <param name="seiNoList">�������ԍ����X�g</param>
        /// <param name="cancelState"></param>
        /// <returns>�o�͌���</returns>
        private bool PutClaimData(List<string> seiNoList, out Boolean cancelState)
        {
            cancelState = false;

            bool ret = false;

            // ���[�ݒ���擾 (�e���v���[�g�ۑ��ꏊ�A�p�X���[�h���j 
            Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo();

            // SaveFileDialog�N���X�̃C���X�^���X���쐬 
            SaveFileDialog sfd = new SaveFileDialog();

            // �͂��߂̃t�@�C�������w�肷�� 
            sfd.FileName = repInfo.field3 + CLAIM_SFD_EXT;

            // �͂��߂ɕ\�������t�H���_���w�肷�� 
            sfd.InitialDirectory = repInfo.field2;

            // [�t�@�C���̎��]�ɕ\�������I�������w�肷�� 
            sfd.Filter = CLAIM_SFD_FILTER;

            // [�t�@�C���̎��]�ł͂��߂� 
            // �u���ׂẴt�@�C���v���I������Ă���悤�ɂ��� 
            sfd.FilterIndex = 0;

            // �^�C�g����ݒ肷�� 
            sfd.Title = CLAIM_SFD_TITLE;

            // �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ��� 
            sfd.RestoreDirectory = true;

            // �_�C�A���O��\������ 
            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                //*************************************
                // �o�͎��s 
                //*************************************
                ret = this.OutFile(sfd.FileName, seiNoList);
            }
            else if (result == DialogResult.Cancel)
            {
                cancelState = true;
            }

            sfd.Dispose();

            return ret;
        }

        /// <summary>
        /// ���[�o�͐ݒ���擾���\�b�h 
        /// </summary>
        /// <returns>���[�o�͐ݒ���</returns>
        private Common.KKHSchema.Common.SystemCommonRow GetReportInfo()
        {
            Common.KKHSchema.Common.SystemCommonRow ret;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult;

            // ���[�ݒ���擾 
            comResult = commonProcessController.FindCommonByCond(_naviParameter.strEsqId,
                                                                _naviParameter.strEgcd,
                                                                _naviParameter.strTksKgyCd,
                                                                _naviParameter.strTksBmnSeqNo,
                                                                _naviParameter.strTksTntSeqNo,
                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                SYSTEM_KEY_SAVEFILE_PATH);

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                ret = comResult.CommonDataSet.SystemCommon[0];
            }
            else
            {
                // �擾�ł��Ȃ������ꍇ�̓f�t�H���g�l��ݒ� 
                Common.KKHSchema.Common.SystemCommonDataTable dt =
                    new Common.KKHSchema.Common.SystemCommonDataTable();
                ret = (Common.KKHSchema.Common.SystemCommonRow)dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ret[i] = string.Empty;
                }

                // �ȉ��A�󕶎��ȊO���f�t�H���g�l�Ƃ��Đݒ� 
                ret.field2 = CLAIM_SFD_INITDIRTMP;      // �ۑ���p�X 
                ret.field3 = CLAIM_SFD_FILENAME;        // �t�@�C���� 
            }

            return ret;
        }   

        /// <summary>
        /// �����f�[�^�o�̓��\�b�h 
        /// </summary>
        /// <param name="fileName">�t�@�C��</param>
        /// <param name="seiNoList">�o�͐������ԍ����X�g</param>
        /// <returns>��������</returns>
        private bool OutFile(string fileName, List<string> seiNoList)
        {
            bool ret = false;
            int rowCount = 0;

            try
            {
                // �ۑ��t�@�C���Ɠ������O�̃t�@�C�������݂���ꍇ 
                if (File.Exists(fileName))
                {
                    if (File.Exists(fileName + "copy"))
                    {
                        File.Delete(fileName + "copy");
                    }

                    // �t�@�C�����ꎞ�ޔ����� 
                    File.Copy(fileName, fileName + "copy");
                }

                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding("shift_jis")))
                {
                    // �����f�[�^���A�o�͐������ԍ����X�g�̐������ԍ��ƈ�v����f�[�^�擾 
                    ClaimDSAcom.ClaimDataDataTable dt = new ClaimDSAcom.ClaimDataDataTable();

                    // �t�B���^�ݒ� 
                    StringBuilder filter = new StringBuilder();
                    foreach (string seiNo in seiNoList)
                    {
                        if (string.IsNullOrEmpty(filter.ToString()))
                        {
                            filter.Append(dt.seiNoColumn.ColumnName + " = '" + seiNo + "'");
                        }
                        else
                        {
                            filter.Append(" OR " + dt.seiNoColumn.ColumnName + " = '" + seiNo + "'");
                        }
                    }

                    // �f�[�^�o�͏��Ƀ\�[�g����
                    dt = SortForOutFile(_dsClaim.ClaimData);

                    // �f�[�^�擾 
                    ClaimDSAcom.ClaimDataRow[] drs = (ClaimDSAcom.ClaimDataRow[])dt.Select(filter.ToString(), "");

                    foreach (ClaimDSAcom.ClaimDataRow row in drs)
                    {
                        StringBuilder sb = new StringBuilder();     // �o�͗p������̐��� 
                        string tmp = string.Empty;                  // �o�̓f�[�^�ꎞ�ێ��p 
                        string sybt = row.sybt;                     // ��� 
                        string baitaiCd = row.baitaiCd;             // �}�̃R�[�h 

                        rowCount += 1;

                        #region �t�@�C���o��.

                        //  1.�˗��ԍ� ------------------------------------------------------------------------------------
                        if (SYBT_S.Equals(sybt))
                        {
                            tmp = row.iraiNo;
                        }
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�˗��ԍ�"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.IRAINO));

                        //  2.�˗��s�ԍ� ----------------------------------------------------------------------------------
                        // ���v�s�̏ꍇ 
                        if (SYBT_T.Equals(sybt))
                        {
                            tmp = "000";
                        }
                        else
                        {
                            tmp = KKHUtility.DecParse(row.iraiGyoNo).ToString("000");
                        }
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�˗��s�ԍ�"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue("+" + tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.IRAIGYONO));

                        //  3.�����R�[�h --------------------------------------------------------------------------------
                        tmp = row.toriCd;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�����R�[�h"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TORICD));

                        //  4.��Ж� --------------------------------------------------------------------------------------
                        tmp = row.kaiNm;
                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "��Ж�"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.KAINM));

                        //  5.���������R�[�h ------------------------------------------------------------------------------
                        tmp = row.seibuCd;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���������R�[�h"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.SEIBUCD));

                        //  6.���㕔���R�[�h ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���㕔���R�[�h"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.URIBUCD));

                        //  7.�����N���� ----------------------------------------------------------------------------------
                        tmp = row.seiYymm;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�����N����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.SEIYYMM));

                        //  8.�������ԍ� ----------------------------------------------------------------------------------
                        tmp = row.seiNo;
                        // ���l�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "�����N����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, ClaimDataItemLength.SEINO));

                        //  9.���e�敪 ------------------------------------------------------------------------------------
                        tmp = row.naiyoKbn;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���e�敪"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.NAIYOKBN));

                        // 10.�l���s�敪 ----------------------------------------------------------------------------------
                        tmp = row.nebiKbn;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�l���s�敪"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.NEBIKBN));

                        // 11.�������s�ԍ� --------------------------------------------------------------------------------
                        if (SYBT_T.Equals(sybt))
                        {
                            tmp = "000";
                        }
                        else
                        {
                            tmp = KKHUtility.DecParse(row.seiGyoNo).ToString("000");
                        }
                        // ���l�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "�����N����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue("+" + tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, ClaimDataItemLength.SEIGYONO));

                        // 12.�x���� --------------------------------------------------------------------------------------
                        tmp = row.payDay;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�x����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.PAYDAY));

                        // 13.�ېŋ敪 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // �ǉ� 
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.KAZEIKBN));

                        // 14.����敪 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // �ǉ� 
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.URIKBN));

                        // 15.����敪���� --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // �ǉ� 
                        sb.Append(tmp.PadLeft(( ClaimDataItemLength.URIKBNNM / 2 ), '�@'));

                        // 16.���i�敪 ------------------------------------------------------------------------------------
                        tmp = row.syohinKbn;
                        if (tmp.Length < ClaimDataItemLength.SYOHINKBN)
                        {
                            if (tmp.Length < ClaimDataItemLength.SYOHINKBN - 1)
                            {
                                // �זڋ敪�����݂���ꍇ�A�����ɒǉ����� 
                                if (!string.IsNullOrEmpty(row.saimokuKbn))
                                {
                                    sb.Append(tmp + row.saimokuKbn);
                                }
                                else
                                {
                                    string space = string.Empty;
                                    sb.Append(tmp + space.PadLeft(1));
                                }
                            }
                            else
                            {
                                string space = string.Empty;
                                sb.Append(tmp + space.PadLeft(ClaimDataItemLength.SYOHINKBN - tmp.Length));
                            }
                        }
                        else
                        {
                            sb.Append(tmp.Substring(0, ClaimDataItemLength.SYOHINKBN));
                        }

                        // 17.���i�敪���� --------------------------------------------------------------------------------
                        tmp = row.syohinKbnNm;
                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���i�敪����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.SYOHINKBNNM));

                        // 18.�E�v�R�[�h ----------------------------------------------------------------------------------
                        tmp = row.tekiyoCd;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�E�v�R�[�h"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TEKIYOCD));

                        // 19.�}�̃R�[�h ----------------------------------------------------------------------------------
                        tmp = row.baitaiCd;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�}�̃R�[�h"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.BAITAICD));

                        // 20.���f�B�A�R�[�h ------------------------------------------------------------------------------
                        tmp = row.mediaCd;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���f�B�A�R�[�h"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEDIACD));

                        // 21.�n�敔���R�[�h ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.TIKBUSCD));

                        // 22.�X�� ----------------------------------------------------------------------------------------
                        tmp = row.tenBan;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�X��"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TENBAN));

                        // 23.���׃R�[�h�P --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAICD1));

                        // 24.���ז��̂P ----------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(( ClaimDataItemLength.MEISAINM1 / 2 ), '�@'));

                        // 25.���׃R�[�h�Q --------------------------------------------------------------------------------
                        // �d�g�A�V���̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd) ||
                            KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }
                        // �G���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // �F���R�[�h 
                            tmp = row.sisaCd;
                        }
                        // ��ʂ̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            // ��ʌf�ڃR�[�h 
                            tmp = row.kotukeiCd;
                        }

                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���׃R�[�h�Q"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD2));

                        // 26.���ז��̂Q ----------------------------------------------------------------------------------
                        // �d�g�A�V���̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd) ||
                            KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }
                        // �G���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // �F������ 
                            tmp = row.sisaNm;
                        }
                        // ��ʂ̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            // ��ʌf�ږ��� 
                            tmp = row.kotukeiNm;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂Q"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM2));

                        // 27.���׃R�[�h�R --------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // �`�ԋ敪�R�[�h 
                            tmp = row.keitaiKbnCd;
                        }
                        // �G���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // �T�C�Y�R�[�h 
                            tmp = row.sizeCd;
                        }
                        // �V���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // �f�ڏꏊ�R�[�h 
                            tmp = row.keisaiBasCd;
                        }
                        // ��ʂ̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }

                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���׃R�[�h�R"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD3));

                        // 28.���ז��̂R ----------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // �`�ԋ敪���� 
                            tmp = row.keitaiKbnNm;
                        }
                        // �G���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // �T�C�Y���� 
                            tmp = row.sizeNm;
                        }
                        // �V���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // �f�ڏꏊ���� 
                            tmp = row.keisaiBasNm;
                        }
                        // ��ʂ̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂R"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM3));

                        // 29.���׃R�[�h�S --------------------------------------------------------------------------------
                        // �V���̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // ���1�R�[�h 
                            tmp = row.sybt1Cd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���׃R�[�h�S"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD4));

                        // 30.���ז��̂S ----------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM�b����1 
                            tmp = row.cm1;
                        }
                        // �V���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // ���1���� 
                            tmp = row.sybt1Nm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂S"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM4));

                        // 31.���׃R�[�h�T --------------------------------------------------------------------------------
                        // �V���̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // ���2�R�[�h 
                            tmp = row.sybt2Cd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���׃R�[�h�T"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD5));

                        // 32.���ז��̂T ----------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // ���e����1 
                            tmp = row.name1;
                        }
                        // �V���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // ���2���� 
                            tmp = row.sybt2Nm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂T"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM5));

                        // 33.���׃R�[�h�U --------------------------------------------------------------------------------
                        // �V���̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // �F���R�[�h 
                            tmp = row.sisaCd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���׃R�[�h�U"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD6));

                        // 34.���ז��̂U ----------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM�b����2 
                            tmp = row.cm2;
                        }
                        // �V���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // �F������ 
                            tmp = row.sisaNm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂U"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM6));

                        // 35.���׃R�[�h�V --------------------------------------------------------------------------------
                        // �V���̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // �T�C�Y�R�[�h 
                            tmp = row.sizeCd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "���׃R�[�h�V"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD7));

                        // 36.���ז��̂V ----------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // ���e����2 
                            tmp = row.name2;
                        }
                        // �V���̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // �T�C�Y���� 
                            tmp = row.sizeNm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // ���S�p���p���݁i�`�F�b�N�Ȃ��j 
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_NONE, ClaimDataItemLength.MEISAINM7));

                        // 37.���׃R�[�h�W --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD8));

                        // 38.���ז��̂W ----------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM�b����3 
                            tmp = row.cm3;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂W"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM8));

                        // 39.���׃R�[�h�X --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAICD9));

                        // 40.���ז��̂X ----------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // ���e����3 
                            tmp = row.name3;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂X"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM9));

                        // 41.���׃R�[�h�P�O ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAICD10));

                        // 42.���ז��̂P�O --------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM�b����4 
                            tmp = row.cm4;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂P�O"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM10));

                        // 43.���ז��̂P�P --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(( ClaimDataItemLength.MEISAINM11 / 2 ), '�@'));

                        // 44.���ז��̂P�Q --------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // ���e����4 
                            tmp = row.name4;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂P�Q"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM12));

                        // 45.���ז��̂P�R --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAINM13));

                        // 46.���ז��̂P�S --------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // �ԑg��1 
                            tmp = row.bngm1;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂P�S"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM14));

                        // 47.���ז��̂P�T --------------------------------------------------------------------------------
                        // ���l�P 
                        tmp = row.biko1;
                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂P�T"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM15));

                        // 48.���ז��̂P�U --------------------------------------------------------------------------------
                        // ���l�Q 
                        tmp = row.biko2;
                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂P�U"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM16));

                        int count = 0;
                        // 49.���ז��̂P�V --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        if (SYBT_S.Equals(sybt))
                        {
                            // �V���̏ꍇ 
                            if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                            {
                                if (0 < row.keisaiDay.Split(',').Length)
                                {
                                    // �f�ړ� 
                                    foreach (string str in row.keisaiDay.Split(','))
                                    {
                                        if (!string.IsNullOrEmpty(str.Trim()))
                                        {
                                            tmp += str;
                                            // �񐔂��J�E���g 
                                            count += 1;
                                        }
                                        else
                                        {
                                            tmp += "0";
                                        }
                                    }
                                }
                                string space = string.Empty;
                                sb.Append(tmp + space.PadLeft(35));

                            }
                            // �G���̏ꍇ 
                            else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                            {
                                // �f�ړ� 
                                string[] keisaiArr = row.keisaiDay.Split(',');
                                if (5 < keisaiArr.Length)
                                {
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (!string.IsNullOrEmpty(keisaiArr[i].Trim()))
                                        {
                                            string space = string.Empty;
                                            tmp += keisaiArr[i].Trim() + space.PadLeft(1);

                                            // �񐔂��J�E���g 
                                            count += 1;
                                        }
                                        else
                                        {
                                            string space = string.Empty;
                                            tmp += keisaiArr[i] + space.PadLeft(9);
                                        }
                                    }
                                }
                                string space2 = string.Empty;
                                sb.Append(tmp + space2.PadLeft(ClaimDataItemLength.MEISAINM17 - tmp.Length));

                            }
                            // ��ʂ̏ꍇ 
                            else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                            {
                                tmp = row.kikan;
                                sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_NONE, ClaimDataItemLength.MEISAINM17));
                            }
                            else
                            {
                                tmp = string.Empty;
                                sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAINM17));
                            }
                        }
                        else
                        {
                            tmp = string.Empty;
                            sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAINM17));
                        }

                        // 50.���ז��̂P�W --------------------------------------------------------------------------------
                        // �V���A�G���̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd) ||
                            KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            tmp = count.ToString("00");
                        }
                        // ��ʂ̏ꍇ 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            tmp = "00" + row.keisaiSu;
                            tmp = tmp.Substring(tmp.Length - 2, 2);
                        }
                        else
                        {
                            tmp = "00";
                        }

                        // ���l�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "���ז��̂P�W"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue("+" + tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, ClaimDataItemLength.MEISAINM18));

                        // 51.���ז��̂P�X --------------------------------------------------------------------------------
                        tmp = "+00000000000";
                        // �ǉ� 
                        sb.Append(tmp);

                        // 52.���ז��̂Q�O --------------------------------------------------------------------------------
                        tmp = "+000.00000";
                        // �ǉ� 
                        sb.Append(tmp);

                        // 53.���ז��̂Q�P --------------------------------------------------------------------------------
                        tmp = "+00000000000";
                        // �ǉ� 
                        sb.Append(tmp);

                        // 54.���ז��̂Q�Q --------------------------------------------------------------------------------
                        tmp = "+000000000.00";
                        // �ǉ� 
                        sb.Append(tmp);

                        // 55.���ז��̂Q�R --------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // �ԑg����2 
                            tmp = row.bngm2;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂Q�R"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM23));

                        // 56.���ז��̂Q�S --------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // �ԑg����3 
                            tmp = row.bngm3;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂Q�S"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM24));

                        // 57.���ז��̂Q�T --------------------------------------------------------------------------------
                        // �d�g�̏ꍇ 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // �ԑg����4 
                            tmp = row.bngm4;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // �S�p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "���ז��̂Q�T"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM25));

                        // 58.���� ----------------------------------------------------------------------------------------
                        sb.Append("+000000000.00");

                        // 59.�P�� ----------------------------------------------------------------------------------------
                        decimal tanka = KKHUtility.DecParse(row.keisaiTnk);
                        if (tanka == 0M)
                        {
                            tmp = "+000000000.00";
                        }
                        else if (tanka < 0M)
                        {
                            tmp = tanka.ToString("000000000") + ".00";
                        }
                        else
                        {
                            tmp = "+" + tanka.ToString("000000000") + ".00";
                        }

                        // ���l�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "�P��"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // �ǉ� 
                        sb.Append(tmp);

                        // 60.JLA���z -------------------------------------------------------------------------------------
                        decimal kingak = row.kingak;
                        if (SYBT_H.Equals(sybt))
                        {
                            tmp = "+0000000000000";
                        }
                        else if (kingak < 0M)
                        {
                            tmp = kingak.ToString("0000000000000");
                        }
                        else
                        {
                            tmp = "+" + kingak.ToString("0000000000000");
                        }

                        // ���l�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "JLA���z"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // �ǉ� 
                        sb.Append(tmp);

                        // 61.JLA����� -----------------------------------------------------------------------------------
                        decimal syohizei = row.syohizei;
                        if (SYBT_H.Equals(sybt))
                        {
                            tmp = "0000000000000";
                        }
                        else if (syohizei < 0M)
                        {
                            tmp = syohizei.ToString("0000000000000");
                        }
                        else
                        {
                            tmp = "+" + syohizei.ToString("0000000000000");
                        }

                        // ���l�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "JLA�����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // �ǉ� 
                        sb.Append(tmp);

                        // 62.JLA���v���z ---------------------------------------------------------------------------------
                        decimal goukei = row.kingakSum;
                        if (SYBT_H.Equals(sybt))
                        {
                            tmp = "0000000000000";
                        }
                        else if (goukei < 0M)
                        {
                            tmp = goukei.ToString("0000000000000");
                        }
                        else
                        {
                            tmp = "+" + goukei.ToString("0000000000000");
                        }

                        // ���l�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "JLA���v���z"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // �ǉ� 
                        sb.Append(tmp);

                        // 63.�����敪 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.SHORIKBN));

                        // 64.�����ԍ� ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.SHORINO));

                        // 65.����� ------------------------------------------------------------------------------------
                        tmp = row.anbunSybt;
                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.ANBUNSYBT));

                        // 66.���p�^�[�� --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.ANBUNPATTERN));

                        // 67.���͏����敪 --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INSHORIKBN));

                        // 68.�v���O�����h�c ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.PRGID));

                        // 69.�[���h�c ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.PCID));

                        // 70.���͕����R�[�h ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INBUSCD));

                        // 71.���͒S���҃R�[�h ----------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INUSERCD));

                        // 72.���͔N�� ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INYYMM));

                        // 73.���͎��� ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INTIME));

                        // 74.�o�^�N���� ----------------------------------------------------------------------------------
                        if (SYBT_T.Equals(sybt))
                        {
                            tmp = String.Empty;

                            // ���ꐿ�����ԍ������ԑ����o�^�����Z�o����.

                            // ���ꐿ�����ԍ���������܂Ń��[�v.
                            for( int i1 = 0; i1 < drs.Length; i1++ )
                            {
                                if( row.seiNo != drs[ i1 ].seiNo )
                                {
                                    continue;
                                }

                                // �ʂ̐������ԍ���������܂Ń��[�v.
                                for( int i2 = i1; i2 < drs.Length; i2++ )
                                {
                                    if( row.seiNo != drs[ i2 ].seiNo )
                                    {
                                        break;
                                    }

                                    if (( String.IsNullOrEmpty(tmp) || ( String.Compare(tmp, drs[i2].touDate) > 0 ) ) && ( !String.IsNullOrEmpty(drs[i2].touDate) ))
                                    {
                                        tmp = drs[i2].touDate;
                                    }
                                }

                                break;
                            }
                        }
                        else
                        {
                            tmp = row.touDate;
                        }

                        // ���p�`�F�b�N 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�o�^�N����"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TOUDATE));

                        // 75.�ύX�N���� ----------------------------------------------------------------------------------
                        tmp = string.Empty;
                        if (SYBT_S.Equals(sybt))
                        {
                            tmp = row.henDate;
                            // ���p�`�F�b�N 
                            if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "�ύX�N����"))
                            {
                                throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                            }
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.HENDATE));

                        // 76.����N���� ----------------------------------------------------------------------------------
                        tmp = string.Empty;
                        if (SYBT_S.Equals(sybt))
                        {
                            tmp = row.torDate;
                            // ���p�`�F�b�N 
                            if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "����N����"))
                            {
                                throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                            }
                        }
                        // �ǉ� 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TORDATE));

                        // �t�@�C���ɏ������� 
                        sw.WriteLine(sb.ToString());

                        #endregion �t�@�C���o��
                    }
                }

                ret = true;
            }
            catch (CheckException cex)
            {
                ret = false;

                if (File.Exists(fileName + "copy"))
                {
                    // �ꎞ�ޔ��t�@�C�������̃t�@�C�����Œu�������� 
                    File.Delete(fileName);
                    File.Move(fileName + "copy", fileName);
                }

                String m = String.Empty;

                m += "�o�͌`���`�F�b�N�G���[" + " ";
                m += "�J�������F" + spdClaimNo_Sheet1.Columns[cex.Index].Label + " ";

                if (cex.Type == KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK)
                {
                    m += "�^�C�v�F�S�p";
                }
                else if (cex.Type == KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK)
                {
                    m += "�^�C�v�F���p";
                }
                else if (cex.Type == KkhConstAcom.AttributeCheckType.CHECKTYPE_SU)
                {
                    m += "�^�C�v�F���l";
                }

                // �o�͗����̓o�^.
                this.RegistLog("���M", this.Text, m, "���[��", "1");
            }
            catch (Exception)
            {
                ret = false;

                if (File.Exists(fileName + "copy"))
                {
                    // �ꎞ�ޔ��t�@�C�������̃t�@�C�����Œu�������� 
                    File.Delete(fileName);
                    File.Move(fileName + "copy", fileName);
                }
            }
            finally
            {
                if (File.Exists(fileName + "copy"))
                {
                    // �ꎞ�ޔ��t�@�C�����폜����  
                    File.Delete(fileName + "copy");
                    //// �ꎞ�ޔ��t�@�C�������̃t�@�C�����Œu�������� 
                    //File.Delete(fileName);
                    //File.Move(fileName + "copy", fileName);
                }
            }

            return ret;
        }

        /// <summary>
        /// �o�̓f�[�^��ݒ肷�郁�\�b�h 
        /// </summary>
        /// <param name="value">�l</param>
        /// <param name="checkType">�`�F�b�N�^�C�v(�S�p�E���p�E���l�E�`�F�b�N����)</param>
        /// <param name="len">����</param>
        /// <returns>�ҏW�����l</returns>
        private string SetStringValue(string value, int checkType, int len)
        {
            string ret = string.Empty;
            int valueLen = KKHUtility.GetByteCount(value);

            if (valueLen < len)
            {
                // �����Ŏw�肳�ꂽ�����ɖ����Ȃ��ꍇ�A�s�������󔒂Ŗ��߂� 
                string space = string.Empty;

                if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK)
                {
                    ret = value + space.PadLeft(( len - valueLen ) / 2, '�@');
                }
                else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK)
                {
                    ret = value + space.PadLeft(len - valueLen, ' ');
                }
                else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_SU)
                {
                    ret = value + space.PadLeft(len - valueLen, ' ');
                }
                else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_NONE)
                {
                    ret = value + space.PadLeft(len - valueLen, ' ');
                }
            }
            else
            {
                // �����Ŏw�肳�ꂽ����������ԋp���� 
                ret = KKHUtility.GetByteString(value, len);
            }

            return ret;
        }

        /// <summary>
        /// �f�[�^�̑����`�F�b�N���\�b�h 
        /// �`�F�b�N�G���[�̏ꍇ���b�Z�[�W��\������ 
        /// </summary>
        /// <param name="checkData">�`�F�b�N�Ώۃf�[�^</param>
        /// <param name="checkType">�`�F�b�N�^�C�v(�S�p�E���p�E���l�E�`�F�b�N����)</param>
        /// <param name="rowNo">�s�ԍ�</param>
        /// <param name="colName">���ږ�</param>
        /// <returns>��������</returns>
        private bool ZokuseiCheck(object checkData, int checkType, int rowNo, string colName)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string zokusei = string.Empty;
            bool result = false;

            // �S�p�`�F�b�N 
            if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK)
            {
                zokusei = "�S�p";
                int num = sjisEnc.GetByteCount(checkData.ToString());
                result = (num == checkData.ToString().Length * 2);
            }

            // ���p�`�F�b�N 
            else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK)
            {
                zokusei = "���p";
                int num = sjisEnc.GetByteCount(checkData.ToString());
                result = (num == checkData.ToString().Length);
            }

            // ���l�`�F�b�N 
            else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_SU)
            {
                zokusei = "���l�ȊO";
                result = KKHUtility.IsNumeric(checkData.ToString());
            }

            // �`�F�b�N�G���[�̏ꍇ 
            if (!result)
            {
                // ���b�Z�[�W��\�� 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0119
                                            , new string[] { rowNo.ToString(), colName, zokusei }
                                            , this.Text
                                            , MessageBoxButtons.OK);
            }

            return result;
        }

        /// <summary>
        /// ���M�t���O�X�V���\�b�h 
        /// </summary>
        /// <param name="seiNoList">�o�͐������ԍ����X�g</param>
        /// <returns>��������</returns>
        private bool UpdateOutFlg(List<string> seiNoList)
        {
            ClaimAcomProcessController.UpdateOutFlgParam param =
                new ClaimAcomProcessController.UpdateOutFlgParam();

            // ���M�t���O�X�V�p�����[�^�ݒ� 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;      // ���O�C���S����ESQID 
            param.egCd = _naviParameter.strEgcd;                        // �c�Ə��i��j�R�[�h 
            param.tksKgyCd = _naviParameter.strTksKgyCd;                // ���Ӑ��ƃR�[�h 
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;          // ���Ӑ敔��SEQNO 
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;          // ���Ӑ�S��SEQNO 
            param.outDate  = DateTime.Now.ToString("yyyy/MM/dd HH:mm"); // �o�͓��� 
            param.outFlg = "2";                                         // �X�V�t���O 
            string seiNo = string.Empty;                                // ������No 
            string sybt = string.Empty;                                 // ��� 

            List<string> pJyutNoList = new List<string>();              // ��No 
            List<string> pJyMeiNoList = new List<string>();             // �󒍖���No 
            List<string> pUrMeiNoList = new List<string>();             // ���㖾��No 
            List<string> pRenBanList = new List<string>();              // �A�� 
            List<string> pSeiNoList = new List<string>();               // ������No 
            List<string> pSeiGyoNoList = new List<string>();            // �������sNo 
            List<string> pSeiYymmList = new List<string>();             // �����N���� 

            foreach (Row row in spdClaim_Sheet1.Rows)
            {
                sybt = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYBT].Value);
                seiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value);

                // �o�͐������ԍ����X�g�ɐ������ԍ������݂��Ȃ��ꍇ 
                if (!seiNoList.Contains(seiNo))
                {
                    // �ΏۊO�̃f�[�^�ׁ̈A�ǂݔ�΂� 
                    continue;
                }

                // ��ʂ��uS�v�ȊO�̏ꍇ 
                if (!SYBT_S.Equals(sybt))
                {

                    // �ΏۊO�̃f�[�^�ׁ̈A�ǂݔ�΂� 
                    continue;
                }

                string[] jyutNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.JYUTNO].Value).Split(',');
                string[] jymeiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.JYMEINO].Value).Split(',');
                string[] urmeiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.URMEINO].Value).Split(',');
                string[] renBan = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.RENBAN].Value).Split(',');

                for (int i = 0; i < jyutNo.Length; i++)
                {
                    pJyutNoList.Add(jyutNo[i]);
                    pJyMeiNoList.Add(jymeiNo[i]);
                    pUrMeiNoList.Add(urmeiNo[i]);
                    pRenBanList.Add(renBan[i]);
                    pSeiNoList.Add(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value));
                    pSeiGyoNoList.Add(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIGYONO].Value));
                    pSeiYymmList.Add(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIYYMM].Value));
                }
            }
            param.jyutNo = pJyutNoList.ToArray();       // ��No 
            param.jyMeiNo = pJyMeiNoList.ToArray();     // �󒍖���No
            param.urMeiNo = pUrMeiNoList.ToArray();     // ���㖾��No
            param.renban = pRenBanList.ToArray();       // �A�� 
            param.seiNo = pSeiNoList.ToArray();         // ������No 
            param.seiGyoNo = pSeiGyoNoList.ToArray();   // �������sNo
            param.seiYymm = pSeiYymmList.ToArray();     // �����N����

            // ���M�t���O�X�V 
            ClaimAcomProcessController processController = ClaimAcomProcessController.GetInstance();
            UpdateOutFlgServiceResult result = processController.UpdateOutFlg(param);

            if (result.HasError == true)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ����o�^���\�b�h 
        /// </summary>
        /// <param name="kbn">�敪</param>
        /// <param name="desc">���e</param>
        /// <param name="errDesc">�G���[���e</param>
        /// <param name="reception">����M���</param>
        /// <param name="status">���M�X�e�[�^�X</param>
        /// <returns>��������</returns>
        private bool RegistLog(string kbn, string desc, string errDesc, string reception, string status)
        {
            //LogProcessController processController;
            //RegistLogServiceResult result;
            //
            //processController = LogProcessController.GetInstance();
            //result = processController.registLog(
            //                                    "ClaiAcom"
            //                                    , _naviParameter.strEsqId
            //                                    , _naviParameter.strEgcd
            //                                    , _naviParameter.strTksKgyCd
            //                                    , _naviParameter.strTksBmnSeqNo
            //                                    , _naviParameter.strTksTntSeqNo
            //                                    , KkhConstAcom.LogShowList.LOG_SHOW
            //                                    , "002"
            //                                    , kbn
            //                                    , desc
            //                                    , errDesc
            //                                    , _naviParameter.strName
            //                                    , reception
            //                                    , status);

            RegistLogServiceResult result = KKHLogUtilityAcom.WriteSendLogToDB(_naviParameter, APLID, desc, errDesc, reception, status);

            if (result.HasError == true)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���͐����L���ɂ���
        /// </summary>
        /// <param name="index"></param>
        private void InputControlOn(int index)
        {
            if (IsInputControlNumberOnly(index))
            {
                spdClaimNo.EditingControl.KeyPress += new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlNumberOnly);
            }
        }

        /// <summary>
        /// ���͐���𖳌��ɂ���
        /// </summary>
        /// <param name="index"></param>
        private void InputControlOff(int index)
        {
            if (IsInputControlNumberOnly(index))
            {
                spdClaimNo.EditingControl.KeyPress -= new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlNumberOnly);
            }
        }

        /// <summary>
        /// �L�[���͐����i�����̂݁j�̑Ώۂ���Ԃ�
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean IsInputControlNumberOnly(int index)
        {
            return (
                ( index == ClaimNoListColNo.SEIYYMM ) ||
                ( index == ClaimNoListColNo.SEINO   )
            );
        }

        /// <summary>
        /// �\�[�g���s��
        /// </summary>
        private void sprSort()
        {
            //����/���� ���وꗗ�^�u�̃\�[�g
            hatyuOrSeikyuSort();

            //�����f�[�^�ꗗ�^�u�̃\�[�g
            SeikyuSort();

        }

        /// <summary>
        /// ����/���� ���وꗗ�^�u�̃\�[�g
        /// </summary>
        private void hatyuOrSeikyuSort()
        {

            string HatyuBan = string.Empty;
            int count = 0;
            //�\�[�g�L�[�̐ݒ�
            string SortKey = string.Empty;
            
            SortKey = "iraiNo Asc,";                               //�����ԍ�(�~��)
            SortKey = SortKey + "iraiGyoNo Asc,";                  //�����s�ԍ��i���o�[(�~��)
            SortKey = SortKey + "sybt Asc,";                       //���(����)
            SortKey = SortKey + "seiNo Asc,";                      //�������ԍ�(����)
            SortKey = SortKey + "seiGyoNo Asc,";                   //�������s�ԍ�(����)
            SortKey = SortKey + "baitaiCd Asc";                   //�}�̃R�[�h(����)


            ClaimDSAcom.ClaimDiffDataDataTable dt = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            ClaimDSAcom.ClaimDiffDataDataTable hoji = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            ClaimDSAcom.ClaimDiffDataDataTable hoji2 = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            ClaimDSAcom.ClaimDiffDataDataTable SpaceTaiou = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            DataView dv = new DataView(_dsClaim.ClaimDiffData);
            dv.Sort = SortKey;
            
            foreach (DataRowView row in dv)
            {
                //�������ԍ��󔒑Ή�--Start1--
                if (count == 0) 
                {
                    HatyuBan = row.Row["iraiNo"].ToString();
                }

                if (!row.Row["iraiNo"].ToString().Equals(HatyuBan))
                {
                    foreach (ClaimDSAcom.ClaimDiffDataRow row1 in SpaceTaiou.Rows)
                    {
                        dt.ImportRow(row1);
                    }
                    SpaceTaiou.Clear();
                    SpaceTaiou.AcceptChanges();
                    HatyuBan = row.Row["iraiNo"].ToString();
                }
                //�������ԍ��󔒑Ή�--End1--

                if (string.IsNullOrEmpty(row.Row["iraiNo"].ToString().Trim()))
                {
                    hoji.ImportRow(row.Row);
                }
                //�������ԍ��󔒑Ή�--Start2--
                else if (string.IsNullOrEmpty(row.Row["seino"].ToString().Trim()) && row.Row["sybt"].Equals(ClaimListColNo.SYBT))
                {
                    SpaceTaiou.ImportRow(row.Row);
                }
                //�������ԍ��󔒑Ή�--End2--
                else
                {
                    dt.ImportRow(row.Row);
                }

                count++;

            }

            


            foreach (ClaimDSAcom.ClaimDiffDataRow hojirow in hoji.Rows)
            {
                if (string.IsNullOrEmpty(hojirow.seiNo.Trim()))
                {
                    hoji2.ImportRow(hojirow);
                }
                else
                {
                    dt.ImportRow(hojirow);
                }
            }

            foreach (ClaimDSAcom.ClaimDiffDataRow hojirow2 in hoji2.Rows)
            {
                dt.ImportRow(hojirow2);
            }

            _dsClaim.ClaimDiffData.Clear();
            _dsClaim.ClaimDiffData.Merge(dt);
            _dsClaim.ClaimDiffData.AcceptChanges();

        }

        /// <summary>
        /// �����f�[�^�ꗗ�^�u�̃\�[�g
        /// </summary>
        private void SeikyuSort()
        {
            //�����ԍ�
            string hatyuNo = string.Empty;
            //�������ԍ�
            string seikyuNo = string.Empty;

            //�\�[�g�L�[�̐ݒ�
            string SortKey = string.Empty;

            SortKey = "iraiNo desc,";                               //�����ԍ�(�~��)
            SortKey = SortKey + "seiNo desc,";                      //�������i���o�[(�~��)
            SortKey = SortKey + "sybt Asc,";                        //���(����)
            SortKey = SortKey + "nebiKbn Asc,";                     //�l���s�敪(����)
            SortKey = SortKey + "iraiGyoNo Asc,";                   //�����s�ԍ�(����)
            SortKey = SortKey + "jyutNo Asc,";                      //��No(����)
            SortKey = SortKey + "jymeiNo Asc,";                     //�󒍖���No(����)
            SortKey = SortKey + "urmeiNo Asc,";                     //����No(����)
            SortKey = SortKey + "renBan Asc";                       //�A��(����)




            //�\�[�g�p�ɃN���[�����쐬
            ClaimDSAcom.ClaimDataDataTable dt = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            // ClaimDSAcom.ClaimDataDataTable dtHai = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            ClaimDSAcom.ClaimDataDataTable dtset = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            ClaimDSAcom.ClaimDataDataTable secResult = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            //�\�[�g���ꂽ�f�[�^�r���[���쐬
            //DataView dv = new DataView(dt);
            //dv.Sort = SortKey;
            //foreach (DataRowView drv in dv)
            //{
            //    dt.ImportRow(drv.Row);
            //}



            #region �P�Ԗڂ̃\�[�g
            //for (int i = 0; i < _dsClaim.ClaimData.Count; i++)
            //{
            //dtHai.Clear();
            //int cunt =0;
            //foreach (ClaimDSAcom.ClaimDataRow hairow in _dsClaim.ClaimData.Rows)
            //{
            //    if (i == 0)
            //    {
            //        dtHai.ImportRow(hairow);
            //    }
            //    if (i != 0 && cunt >= i)
            //    {
            //        dtHai.ImportRow(hairow);
            //    }
            //    cunt++;
            //}

            //�\�[�g���ꂽ�f�[�^�r���[���쐬
            DataView dv = new DataView(_dsClaim.ClaimData);
            dv.Sort = SortKey;
            int endrow = _dsClaim.ClaimData.Rows.Count;
            SortKey = string.Empty;
            SortKey = "iraiNo Asc,";                               //�����ԍ�(����)
            SortKey = SortKey + "seiNo desc,";                      //�������i���o�[(�~��)
            SortKey = SortKey + "sybt Asc,";                        //���(����)
            SortKey = SortKey + "nebiKbn Asc,";                     //�l���s�敪(����)
            SortKey = SortKey + "iraiGyoNo Asc,";                   //�����s�ԍ�(����)
            SortKey = SortKey + "jyutNo Asc,";                      //��No(����)
            SortKey = SortKey + "jymeiNo Asc,";                     //�󒍖���No(����)
            SortKey = SortKey + "urmeiNo Asc,";                     //����No(����)
            SortKey = SortKey + "renBan Asc";                       //�A��(����)
            dv.Sort = SortKey;
            for (int i = 0; i < endrow; i++)
            {
                DataRow delInserRow = dv[0].Row;
                dtset.ImportRow(delInserRow);
                dv[0].Row.Delete();
                dv.Sort = SortKey;
            }


            //foreach (DataRowView drv in dv)
            //{
            //    dtset.ImportRow(drv.Row);
            //    break;
            //}

            //}
            #endregion

            #region �Q�Ԗڂ̃\�[�g

            int count1 = 0;              //�J�E���g
            bool SeikyuUMU = true;      //�������ԍ��̗L��(�L:True,��:False)
            SortKey = string.Empty;
            SortKey = "iraiNo Asc,";                               //�����ԍ�(����)
            SortKey = SortKey + "seiNo Asc,";                      //�������i���o�[(����)
            SortKey = SortKey + "sybt Asc,";                        //���(����)
            SortKey = SortKey + "nebiKbn Asc,";                     //�l���s�敪(����)
            SortKey = SortKey + "iraiGyoNo Asc,";                   //�����s�ԍ�(����)
            SortKey = SortKey + "jyutNo Asc,";                      //��No(����)
            SortKey = SortKey + "jymeiNo Asc,";                     //�󒍖���No(����)
            SortKey = SortKey + "urmeiNo Asc,";                     //����No(����)
            SortKey = SortKey + "renBan Asc";                       //�A��(����)
            //DataView dtsetView = new DataView(dtset);
            //foreach (DataRowView vrow in dtsetView)
            //{
            //    if (count1 == 0)
            //    {
            //        hatyuNo = vrow.Row["iraiNo"].ToString().Trim();
            //    }

            //    if (!hatyuNo.Equals(vrow.Row["iraiNo"].ToString().Trim()))
            //    {

            //        hatyuNo = vrow.Row["iraiNo"].ToString().Trim();
            //    }
            //    count1++;
            //}



            foreach (ClaimDSAcom.ClaimDataRow row in dtset.Rows)
            {

                if (count1 == 0)                         //�P�s�ڂ��m�F
                {
                    hatyuNo = row.iraiNo.Trim();    //�����ԍ���ێ�
                    if (row.seiNo.Trim().Length > 0)
                    {
                        SeikyuUMU = true;
                    }
                    else
                    {
                        SeikyuUMU = false;
                    }
                }

                //�J�����g�̔����ԍ��ƕێ����������ԍ����s��v���m�F
                if (!hatyuNo.Equals(row.iraiNo.Trim()))
                {
                    //�������m��������ꍇ�\�[�g���s��
                    if (SeikyuUMU)
                    {
                        DataView dtsetView = new DataView(dt);
                        dtsetView.Sort = SortKey;

                        foreach (DataRowView dtsetrowview in dtsetView)
                        {
                            secResult.ImportRow(dtsetrowview.Row);
                        }


                    }
                    else
                    {
                        foreach (ClaimDSAcom.ClaimDataRow korow in dt.Rows)
                        {
                            secResult.ImportRow(korow);
                        }

                    }
                    dt.Clear();
                    dt.ImportRow(row);
                    //if (sortStartRow > 0)                           //�\�[�g�J�n�ʒu���擾����Ă��邩�m�F
                    //{

                    //}
                    hatyuNo = row.iraiNo.Trim();            //�J�����g�̔����ԍ���ێ�

                    //�J�����g�̐����i���o�[�̗L�����m�F����
                    if (row.seiNo.Trim().Length > 0)
                    {
                        SeikyuUMU = true;
                    }
                    else
                    {
                        SeikyuUMU = false;
                    }
                }
                else
                {
                    //�J�����g�s��ǉ�����
                    dt.ImportRow(row);

                    //�ŏI�s�̏ꍇ
                    if (count1 == dtset.Rows.Count - 1)
                    {
                        //�������m��������ꍇ�\�[�g���s��
                        if (SeikyuUMU)
                        {
                            DataView dtsetView = new DataView(dt);
                            dtsetView.Sort = SortKey;

                            foreach (DataRowView dtsetrowview in dtsetView)
                            {
                                secResult.ImportRow(dtsetrowview.Row);
                            }

                            dt.Clear();
                        }
                        else
                        {
                            foreach (ClaimDSAcom.ClaimDataRow korow in dt.Rows)
                            {
                                secResult.ImportRow(korow);
                            }
                        }
                    }
                }
                count1++;
            }

            #endregion

            #region �R�Ԗڂ̃\�[�g

            dt.Clear();
            dtset.Clear();
            SortKey = string.Empty;
            hatyuNo = string.Empty;
            seikyuNo = string.Empty;

            int count2 = 0; //�J�E���g
            foreach (ClaimDSAcom.ClaimDataRow row in secResult.Rows)
            {
                //�ŏ��̍s�̏ꍇ�A�����ԍ��A�������ԍ���ێ�����
                if (count2 == 0)
                {
                    hatyuNo = row.iraiNo.Trim();
                    seikyuNo = row.seiNo.Trim();
                }

                //�����ԍ�"�܂���"�������ԍ����قȂ����ꍇ�B
                if (!hatyuNo.Equals(row.iraiNo.Trim()) || !seikyuNo.Equals(row.seiNo.Trim()))
                {



                    SortKey = string.Empty;
                    if (row.baitaiCd.Trim().Equals(KkhConstAcom.MediaKindCode.SYBT_KOTU))
                    {
                        SortKey = "iraiNo desc,";                               //�����ԍ�(����)
                        SortKey = SortKey + "seiNo desc,";                      //�������i���o�[(����)
                        SortKey = SortKey + "sybt Asc,";                        //���(����)
                        SortKey = SortKey + "nebiKbn Asc,";                     //�l���s�敪(����)
                        SortKey = SortKey + "iraiGyoNo Asc,";                   //�����s�ԍ�(����)
                        SortKey = SortKey + "jyutNo Asc,";                      //��No(����)
                        SortKey = SortKey + "jymeiNo Asc,";                     //�󒍖���No(����)
                        SortKey = SortKey + "urmeiNo Asc,";                     //����No(����)
                        SortKey = SortKey + "renBan Asc";                       //�A��(����)
                    }
                    else
                    {
                        SortKey = "iraiNo Asc,";                                //�����ԍ�(����)
                        SortKey = SortKey + "seiNo Asc,";                       //�������i���o�[(����)
                        SortKey = SortKey + "sybt Asc,";                        //���(����)
                        SortKey = SortKey + "nebiKbn Asc,";                     //�l���s�敪(����)
                        SortKey = SortKey + "mediaCd Asc,";                     //���f�B�A�R�[�h(����)
                        SortKey = SortKey + "iraiGyoNo Asc,";                   //�����s�ԍ�(����)
                        SortKey = SortKey + "jyutNo Asc,";                      //��No(����)
                        SortKey = SortKey + "jymeiNo Asc,";                     //�󒍖���No(����)
                        SortKey = SortKey + "urmeiNo Asc,";                     //����No(����)
                        SortKey = SortKey + "renBan Asc";                       //�A��(����)
                    }
                    DataView dvs = new DataView(dt);
                    dvs.Sort = SortKey;
                    foreach (DataRowView dvsrow in dvs)
                    {
                        dtset.ImportRow(dvsrow.Row);
                    }

                    dt.Clear();
                    dt.ImportRow(row);

                    hatyuNo = row.iraiNo.Trim();
                    seikyuNo = row.seiNo.Trim();
                }
                else
                {
                    dt.ImportRow(row);

                    //�ŏI�s�̏ꍇ
                    if (count2 == secResult.Rows.Count - 1)
                    {
                        SortKey = string.Empty;
                        if (row.baitaiCd.Trim().Equals(KkhConstAcom.MediaKindCode.SYBT_KOTU))
                        {
                            SortKey = "iraiNo desc,";                               //�����ԍ�(����)
                            SortKey = SortKey + "seiNo desc,";                      //�������i���o�[(����)
                            SortKey = SortKey + "sybt Asc,";                        //���(����)
                            SortKey = SortKey + "nebiKbn Asc,";                     //�l���s�敪(����)
                            SortKey = SortKey + "iraiGyoNo Asc,";                   //�����s�ԍ�(����)
                            SortKey = SortKey + "jyutNo Asc,";                      //��No(����)
                            SortKey = SortKey + "jymeiNo Asc,";                     //�󒍖���No(����)
                            SortKey = SortKey + "urmeiNo Asc,";                     //����No(����)
                            SortKey = SortKey + "renBan Asc";                       //�A��(����)
                        }
                        else
                        {
                            SortKey = "iraiNo Asc,";                                //�����ԍ�(����)
                            SortKey = SortKey + "seiNo Asc,";                       //�������i���o�[(����)
                            SortKey = SortKey + "sybt Asc,";                        //���(����)
                            SortKey = SortKey + "nebiKbn Asc,";                     //�l���s�敪(����)
                            SortKey = SortKey + "mediaCd Asc,";                     //���f�B�A�R�[�h(����)
                            SortKey = SortKey + "iraiGyoNo Asc,";                   //�����s�ԍ�(����)
                            SortKey = SortKey + "jyutNo Asc,";                      //��No(����)
                            SortKey = SortKey + "jymeiNo Asc,";                     //�󒍖���No(����)
                            SortKey = SortKey + "urmeiNo Asc,";                     //����No(����)
                            SortKey = SortKey + "renBan Asc";                       //�A��(����)
                        }
                        DataView dvs = new DataView(dt);
                        dvs.Sort = SortKey;
                        foreach (DataRowView dvsrow in dvs)
                        {
                            dtset.ImportRow(dvsrow.Row);
                        }

                        dt.Clear();
                    }
                }
                count2++;
            }

            #endregion

            _dsClaim.ClaimData.Clear();
            _dsClaim.ClaimData.Merge(dtset);
            _dsClaim.ClaimData.AcceptChanges();
        }

        /// <summary>
        /// �o�̓f�[�^�p�Ƀ\�[�g����.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private ClaimDSAcom.ClaimDataDataTable SortForOutFile( ClaimDSAcom.ClaimDataDataTable source )
        {
            // �ҏW�p�e�[�u��.
            ClaimDSAcom.ClaimDataDataTable dtw = new ClaimDSAcom.ClaimDataDataTable();

            // �o�͗p�e�[�u��.
            ClaimDSAcom.ClaimDataDataTable dto = new ClaimDSAcom.ClaimDataDataTable();

            // �u���C�N�p�L�[.
            String strBaitaiCdKey = String.Empty;

            // �\�[�g�����i�����j.
            const String order1 = "seiNo, sybt DESC";

            // �\�[�g�����i��ʁj.
            const String order2 = "seiNo, sybt DESC, seiGyoNo";

            // �\�[�g�����i��ʈȊO�j.
            const String order3 = "seiNo, sybt DESC, mediaCd, seiGyoNo";

            // �e�[�u������ɂ���.
            dtw.Clear();

            dto.Clear();

            // ���̓e�[�u���Ƀ\�[�g�����i�����j��K�p���ă��[�v.
            foreach (ClaimDSAcom.ClaimDataRow r1 in (ClaimDSAcom.ClaimDataRow[])source.Select("", order1))
            {
                // �}�̃R�[�h�Ńu���C�N.
                if (strBaitaiCdKey != r1.baitaiCd)
                {
                    // �L�[����̏ꍇ�ɃX���[�i�ŏ��̃��[�v�̏ꍇ�j.
                    if (!String.IsNullOrEmpty(strBaitaiCdKey))
                    {
                        // �\�[�g�����i�[�p.
                        String ow = String.Empty;

                        // ��ʂ̃\�[�g����.
                        if (strBaitaiCdKey == KkhConstAcom.MediaKindCode.SYBT_KOTU)
                        {
                            ow = order2;
                        }
                        // ��ʈȊO�̃\�[�g����.
                        else
                        {
                            ow = order3;
                        }

                        // �ҏW�p�e�[�u���Ƀ\�[�g������K�p���ďo�͗p�e�[�u���ɒǉ�.
                        foreach (ClaimDSAcom.ClaimDataRow r2 in (ClaimDSAcom.ClaimDataRow[])dtw.Select("", ow))
                        {
                            dto.ImportRow(r2);
                        }

                        // �ҏW�p�e�[�u�����N���A.
                        dtw.Clear();
                    }

                    // �u���C�N�p�L�[���X�V.
                    strBaitaiCdKey = r1.baitaiCd;
                }

                // �ҏW�p�e�[�u���ɒǉ�.
                dtw.ImportRow(r1);
            }

            // �L�[����̏ꍇ�ɃX���[�i�ŏ��̃��[�v�̏ꍇ�j.
            if (!String.IsNullOrEmpty(strBaitaiCdKey))
            {
                // �\�[�g�����i�[�p.
                String ow = String.Empty;

                // ��ʂ̃\�[�g����.
                if (strBaitaiCdKey == KkhConstAcom.MediaKindCode.SYBT_KOTU)
                {
                    ow = order2;
                }
                // ��ʈȊO�̃\�[�g����.
                else
                {
                    ow = order3;
                }

                // �ҏW�p�e�[�u���Ƀ\�[�g������K�p���ďo�͗p�e�[�u���ɒǉ�.
                foreach (ClaimDSAcom.ClaimDataRow r in (ClaimDSAcom.ClaimDataRow[])dtw.Select("", ow))
                {
                    dto.ImportRow(r);
                }

                // �ҏW�p�e�[�u�����N���A.
                dtw.Clear();
            }

            // �\�[�g���ʂ�Ԃ�.
            return dto;
        }

        /// <summary>
        /// OK�{�^���N���b�N���\�b�h 
        /// </summary>
        private void BtnOutClick()
        { 
                        // �����f�[�^�o�̓`�F�b�N�i����/�����ԍ� �ꗗ�j 
            List<string> seiNoList;
            Boolean cancelState = false;

            if (!this.PutClimDataCheckClaimNo(out seiNoList))
            {
                return;
            }

            // �����f�[�^�o�̓`�F�b�N�i�����f�[�^ �ꗗ�j 
            if (!this.PutClaimDataCheckClaim(seiNoList))
            {
                return;
            }

            // �����f�[�^�o�� 
            if (!this.PutClaimData(seiNoList, out cancelState))
            {
                // �t�@�C���I���_�C�A���O���L�����Z���̏ꍇ�̓��b�Z�[�W���o�����ɏI��.
                if (cancelState)
                {
                    return;
                }

                // ���b�Z�[�W�\�� 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0121, null, this.Text, MessageBoxButtons.OK);
                return;
            }

            // ���M�t���O�X�V 
            if (!this.UpdateOutFlg(seiNoList))
            {
                return;
            }

            // �o�͗����̓o�^ 
            if (!this.RegistLog("���M", this.Text, " ", "���[��", "0"))
            {
                return;
            }

            // �I�y���[�V�������O�̏o��
            KKHLogUtilityAcom.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityAcom.KINO_ID_OPERATION_LOG_CLAME, KKHLogUtilityAcom.DESC_OPERATION_LOG_CLAIM);

            // ���b�Z�[�W�\�� 
            MessageUtility.ShowMessageBox(MessageCode.HB_I0007, null, this.Text, MessageBoxButtons.OK);

        }

        /// <summary>
        /// �����{�^���N���b�N���\�b�h 
        /// </summary>
        private void BtnSrcClick()
        {

            base.ShowLoadingDialog();

            // �f�[�^���� 
            if (0 < this.FindReportData())
            {
                //�\�[�g���s��
                sprSort();

                // ����/�����ԍ� ���وꗗ�̔w�i�F��ݒ� 
                this.SetBackColorForClaimDiff();

                // �����敪�̔��菈�� 
                Dictionary<string, string> shoriKbnList = this.ShoriKbnCheck();

                // �����f�[�^ �ꗗ�̔w�i�F��ݒ� 
                this.SetBackColorForClaim(shoriKbnList);

                // ����/�����ԍ� �ꗗ�̔w�i�F��ݒ� 
                this.SetBackColorForClaimNo(shoriKbnList);


                HokanDs.Clear();
                HokanDs.Merge(_dsClaim);
                HokanDs.AcceptChanges();

                base.CloseLoadingDialog();
                this.btnOut.Enabled = true;
                statusStrip1.Items["tslval1"].Text = spdClaimNo_Sheet1.Rows.Count.ToString() + "��"; ;
            }
            else
            {
                base.CloseLoadingDialog();
                this.btnOut.Enabled = false;
                statusStrip1.Items["tslval1"].Text = "0��";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
            }

        }

        #endregion ���\�b�h 
    }
}