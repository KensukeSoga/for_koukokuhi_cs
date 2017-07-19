package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj27LogCrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�����Ǘ��ύX���ODAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj27LogCrCreateDataDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private Tbj27LogCrCreateDataCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{LOAD, COND,  };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj27LogCrCreateDataDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj27LogCrCreateData.DCARCD
                ,Tbj27LogCrCreateData.PHASE
                ,Tbj27LogCrCreateData.CRDATE
                ,Tbj27LogCrCreateData.SEQUENCENO
                ,Tbj27LogCrCreateData.HISTORYNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj27LogCrCreateData.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj27LogCrCreateData.CRTDATE
                ,Tbj27LogCrCreateData.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj27LogCrCreateData.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj27LogCrCreateData.DCARCD
                ,Tbj27LogCrCreateData.PHASE
                ,Tbj27LogCrCreateData.CRDATE
                ,Tbj27LogCrCreateData.SEQUENCENO
                ,Tbj27LogCrCreateData.HISTORYNO
                ,Tbj27LogCrCreateData.HISTORYKBN
                ,Tbj27LogCrCreateData.CLASSDIV
                ,Tbj27LogCrCreateData.SORTNO
                ,Tbj27LogCrCreateData.CLASSCD
                ,Tbj27LogCrCreateData.EXPCD
                ,Tbj27LogCrCreateData.EXPENSE
                ,Tbj27LogCrCreateData.DETAIL
                ,Tbj27LogCrCreateData.KIKANS
                ,Tbj27LogCrCreateData.KIKANE
                ,Tbj27LogCrCreateData.CONTRACTDATE
                ,Tbj27LogCrCreateData.CONTRACTTERM
                ,Tbj27LogCrCreateData.SEIKYU
                ,Tbj27LogCrCreateData.TRTHSKGYCD
                ,Tbj27LogCrCreateData.TRSEQNO
                ,Tbj27LogCrCreateData.ORDERNO
                ,Tbj27LogCrCreateData.PAY
                ,Tbj27LogCrCreateData.HRTHSKGYCD
                ,Tbj27LogCrCreateData.HRSEQNO
                ,Tbj27LogCrCreateData.USERNAME
                ,Tbj27LogCrCreateData.GETMONEY
                ,Tbj27LogCrCreateData.GETCONF
                ,Tbj27LogCrCreateData.PAYMONEY
                ,Tbj27LogCrCreateData.PAYCONF
                ,Tbj27LogCrCreateData.ESTMONEY
                ,Tbj27LogCrCreateData.CLMMONEY
                ,Tbj27LogCrCreateData.DELIVERDAY
                ,Tbj27LogCrCreateData.SETMONTH
                ,Tbj27LogCrCreateData.DIVCD
                ,Tbj27LogCrCreateData.GROUPCD
                ,Tbj27LogCrCreateData.STKYKNO
                ,Tbj27LogCrCreateData.EGTYKFLG
                ,Tbj27LogCrCreateData.INPUTTNTCD
                ,Tbj27LogCrCreateData.CPTNTNM
                ,Tbj27LogCrCreateData.NOTE
                ,Tbj27LogCrCreateData.TCKEY
                ,Tbj27LogCrCreateData.TRSUBNO
                ,Tbj27LogCrCreateData.HRSUBNO
                ,Tbj27LogCrCreateData.RSTATUS
                ,Tbj27LogCrCreateData.STPKBN
                ,Tbj27LogCrCreateData.DCARCDFLG
                ,Tbj27LogCrCreateData.CLASSCDFLG
                ,Tbj27LogCrCreateData.EXPCDFLG
                ,Tbj27LogCrCreateData.EXPENSEFLG
                ,Tbj27LogCrCreateData.DETAILFLG
                ,Tbj27LogCrCreateData.KIKANSFLG
                ,Tbj27LogCrCreateData.KIKANEFLG
                ,Tbj27LogCrCreateData.CONTRACTDATEFLG
                ,Tbj27LogCrCreateData.CONTRACTTERMFLG
                ,Tbj27LogCrCreateData.SEIKYUFLG
                ,Tbj27LogCrCreateData.ORDERNOFLG
                ,Tbj27LogCrCreateData.PAYFLG
                ,Tbj27LogCrCreateData.USERNAMEFLG
                ,Tbj27LogCrCreateData.GETMONEYFLG
                ,Tbj27LogCrCreateData.GETCONFIRMFLG
                ,Tbj27LogCrCreateData.PAYMONEYFLG
                ,Tbj27LogCrCreateData.PAYCONFIRMFLG
                ,Tbj27LogCrCreateData.ESTMONEYFLG
                ,Tbj27LogCrCreateData.CLMMONEYFLG
                ,Tbj27LogCrCreateData.DELIVERDAYFLG
                ,Tbj27LogCrCreateData.SETMONTHFLG
                ,Tbj27LogCrCreateData.DIVISIONFLG
                ,Tbj27LogCrCreateData.GROUPCDFLG
                ,Tbj27LogCrCreateData.STKYKNOFLG
                ,Tbj27LogCrCreateData.EGTYKFLGFLG
                ,Tbj27LogCrCreateData.INPUTTNTCDFLG
                ,Tbj27LogCrCreateData.CPTNTNMFLG
                ,Tbj27LogCrCreateData.NOTEFLG
                ,Tbj27LogCrCreateData.DCARCDCONFFLG
                ,Tbj27LogCrCreateData.DCARCDCONFSIKCD
                ,Tbj27LogCrCreateData.DCARCDCONFHAMID
                ,Tbj27LogCrCreateData.CLASSCDCONFFLG
                ,Tbj27LogCrCreateData.CLASSCDCONFSIKCD
                ,Tbj27LogCrCreateData.CLASSCDCONFHAMID
                ,Tbj27LogCrCreateData.EXPCDCONFFLG
                ,Tbj27LogCrCreateData.EXPCDCONFSIKCD
                ,Tbj27LogCrCreateData.EXPCDCONFHAMID
                ,Tbj27LogCrCreateData.EXPENSECONFFLG
                ,Tbj27LogCrCreateData.EXPENSECONFSIKCD
                ,Tbj27LogCrCreateData.EXPENSECONFHAMID
                ,Tbj27LogCrCreateData.DETAILCONFFLG
                ,Tbj27LogCrCreateData.DETAILCONFSIKCD
                ,Tbj27LogCrCreateData.DETAILCONFHAMID
                ,Tbj27LogCrCreateData.KIKANSCONFFLG
                ,Tbj27LogCrCreateData.KIKANSCONFSIKCD
                ,Tbj27LogCrCreateData.KIKANSCONFHAMID
                ,Tbj27LogCrCreateData.KIKANECONFFLG
                ,Tbj27LogCrCreateData.KIKANECONFSIKCD
                ,Tbj27LogCrCreateData.KIKANECONFHAMID
                ,Tbj27LogCrCreateData.CONTRACTDATECONFFLG
                ,Tbj27LogCrCreateData.CONTRACTDATECONFSIKCD
                ,Tbj27LogCrCreateData.CONTRACTDATECONFHAMID
                ,Tbj27LogCrCreateData.CONTRACTTERMCONFFLG
                ,Tbj27LogCrCreateData.CONTRACTTERMCONFSIKCD
                ,Tbj27LogCrCreateData.CONTRACTTERMCONFHAMID
                ,Tbj27LogCrCreateData.SEIKYUCONFFLG
                ,Tbj27LogCrCreateData.SEIKYUCONFSIKCD
                ,Tbj27LogCrCreateData.SEIKYUCONFHAMID
                ,Tbj27LogCrCreateData.ORDERNOCONFFLG
                ,Tbj27LogCrCreateData.ORDERNOCONFSIKCD
                ,Tbj27LogCrCreateData.ORDERNOCONFHAMID
                ,Tbj27LogCrCreateData.PAYCONFFLG
                ,Tbj27LogCrCreateData.PAYCONFSIKCD
                ,Tbj27LogCrCreateData.PAYCONFHAMID
                ,Tbj27LogCrCreateData.USERNAMECONFFLG
                ,Tbj27LogCrCreateData.USERNAMECONFSIKCD
                ,Tbj27LogCrCreateData.USERNAMECONFHAMID
                ,Tbj27LogCrCreateData.GETMONEYCONFFLG
                ,Tbj27LogCrCreateData.GETMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.GETMONEYCONFHAMID
                ,Tbj27LogCrCreateData.GETCONFCONFFLG
                ,Tbj27LogCrCreateData.GETCONFCONFSIKCD
                ,Tbj27LogCrCreateData.GETCONFCONFHAMID
                ,Tbj27LogCrCreateData.PAYMONEYCONFFLG
                ,Tbj27LogCrCreateData.PAYMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.PAYMONEYCONFHAMID
                ,Tbj27LogCrCreateData.PAYCONFCONFFLG
                ,Tbj27LogCrCreateData.PAYCONFCONFSIKCD
                ,Tbj27LogCrCreateData.PAYCONFCONFHAMID
                ,Tbj27LogCrCreateData.ESTMONEYCONFFLG
                ,Tbj27LogCrCreateData.ESTMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.ESTMONEYCONFHAMID
                ,Tbj27LogCrCreateData.CLMMONEYCONFFLG
                ,Tbj27LogCrCreateData.CLMMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.CLMMONEYCONFHAMID
                ,Tbj27LogCrCreateData.DELIVERDAYCONFFLG
                ,Tbj27LogCrCreateData.DELIVERDAYCONFSIKCD
                ,Tbj27LogCrCreateData.DELIVERDAYCONFHAMID
                ,Tbj27LogCrCreateData.SETMONTHCONFFLG
                ,Tbj27LogCrCreateData.SETMONTHCONFSIKCD
                ,Tbj27LogCrCreateData.SETMONTHCONFHAMID
                ,Tbj27LogCrCreateData.DIVISIONCONFFLG
                ,Tbj27LogCrCreateData.DIVISIONCONFSIKCD
                ,Tbj27LogCrCreateData.DIVISIONCONFHAMID
                ,Tbj27LogCrCreateData.GROUPCDCONFFLG
                ,Tbj27LogCrCreateData.GROUPCDCONFSIKCD
                ,Tbj27LogCrCreateData.GROUPCDCONFHAMID
                ,Tbj27LogCrCreateData.STKYKNOCONFFLG
                ,Tbj27LogCrCreateData.STKYKNOCONFSIKCD
                ,Tbj27LogCrCreateData.STKYKNOCONFHAMID
                ,Tbj27LogCrCreateData.EGTYKCONFFLG
                ,Tbj27LogCrCreateData.EGTYKCONFSIKCD
                ,Tbj27LogCrCreateData.EGTYKCONFHAMID
                ,Tbj27LogCrCreateData.INPUTTNTCDCONFFLG
                ,Tbj27LogCrCreateData.INPUTTNTCDCONFSIKCD
                ,Tbj27LogCrCreateData.INPUTTNTCDCONFHAMID
                ,Tbj27LogCrCreateData.CPTNTNMCONFFLG
                ,Tbj27LogCrCreateData.CPTNTNMCONFSIKCD
                ,Tbj27LogCrCreateData.CPTNTNMCONFHAMID
                ,Tbj27LogCrCreateData.NOTECONFFLG
                ,Tbj27LogCrCreateData.NOTECONFSIKCD
                ,Tbj27LogCrCreateData.NOTECONFHAMID
                ,Tbj27LogCrCreateData.CRTDATE
                ,Tbj27LogCrCreateData.CRTNM
                ,Tbj27LogCrCreateData.CRTAPL
                ,Tbj27LogCrCreateData.CRTID
                ,Tbj27LogCrCreateData.UPDDATE
                ,Tbj27LogCrCreateData.UPDNM
                ,Tbj27LogCrCreateData.UPDAPL
                ,Tbj27LogCrCreateData.UPDID
        };
    }

    /**
     * Condtion����VO�ɕϊ�����
     * @param cond
     * @return
     */
    private Tbj27LogCrCreateDataVO convertCondToVo(Tbj27LogCrCreateDataCondition cond) {
        Tbj27LogCrCreateDataVO vo = new Tbj27LogCrCreateDataVO();

        vo.setDCARCD(cond.getDcarcd());                                                 //�d�ʎԎ�R�[�h
        vo.setPHASE(cond.getPhase());                                                   //�t�F�C�Y
        vo.setCRDATE(cond.getCrdate());                                                 //�N��
        vo.setSEQUENCENO(cond.getSequenceno());                                         //�����Ǘ�NO
        vo.setHISTORYNO(cond.getHistoryno());                                           //����NO
        vo.setHISTORYKBN(cond.getHistorykbn());                                         //�����敪
        vo.setCLASSDIV(cond.getClassdiv());                                             //��ʔ��f�t���O
        vo.setSORTNO(cond.getSortno());                                                 //�\�[�g��
        vo.setCLASSCD(cond.getClasscd());                                               //�\�Z���ރR�[�h
        vo.setEXPCD(cond.getExpcd());                                                   //�\�Z�\��ڃR�[�h
        vo.setEXPENSE(cond.getExpense());                                               //���
        vo.setDETAIL(cond.getDetail());                                                 //�ڍ�
        vo.setKIKANS(cond.getKikans());                                                 //���ԊJ�n
        vo.setKIKANE(cond.getKikane());                                                 //���ԏI��
        vo.setCONTRACTDATE(cond.getContractdate());                                     //�_��J�n�N����
        vo.setCONTRACTTERM(cond.getContractterm());                                     //�_�����(����)
        vo.setSEIKYU(cond.getSeikyu());                                                 //������
        vo.setTRTHSKGYCD(cond.getTrthskgycd());                                         //�����������ƃR�[�h
        vo.setTRSEQNO(cond.getTrseqno());                                               //������r�d�p�m�n
        vo.setORDERNO(cond.getOrderno());                                               //��NO
        vo.setPAY(cond.getPay());                                                       //�x����
        vo.setHRTHSKGYCD(cond.getHrthskgycd());                                         //�x���������ƃR�[�h
        vo.setHRSEQNO(cond.getHrseqno());                                               //�x����r�d�p�m�n
        vo.setUSERNAME(cond.getUsername());                                             //�S����
        vo.setGETMONEY(cond.getGetmoney());                                             //�����z
        vo.setGETCONF(cond.getGetconf());                                               //�����z�m�F
        vo.setPAYMONEY(cond.getPaymoney());                                             //�������z
        vo.setPAYCONF(cond.getPayconf());                                               //�������z�m�F
        vo.setESTMONEY(cond.getEstmoney());                                             //���ϋ��z
        vo.setCLMMONEY(cond.getClmmoney());                                             //�������z
        vo.setDELIVERDAY(cond.getDeliverday());                                         //�x����[�i��
        vo.setSETMONTH(cond.getSetmonth());                                             //�ݒ茎
        vo.setDIVCD(cond.getDivcd());                                                   //�敪�R�[�h
        vo.setGROUPCD(cond.getGroupcd());                                               //�O���[�v�R�[�h
        vo.setSTKYKNO(cond.getStkykno());                                               //�ݒ�ǃi���o�[
        vo.setEGTYKFLG(cond.getEgtykflg());                                             //�c���`�F�b�N
        vo.setINPUTTNTCD(cond.getInputtntcd());                                         //���͒S���R�[�h
        vo.setCPTNTNM(cond.getCptntnm());                                               //CP�S���Җ�
        vo.setNOTE(cond.getNote());                                                     //���l
        vo.setTCKEY(cond.getTckey());                                                   //TCKEY
        vo.setTRSUBNO(cond.getTrsubno());                                               //��T�u�m�n
        vo.setHRSUBNO(cond.getHrsubno());                                               //���T�u�m�n
        vo.setRSTATUS(cond.getRstatus());                                               //�A�g�X�e�[�^�X
        vo.setSTPKBN(cond.getStpkbn());                                                 //���~�敪
        vo.setDCARCDFLG(cond.getDcarcdflg());                                           //�d�ʎԎ�R�[�h�t���O
        vo.setCLASSCDFLG(cond.getClasscdflg());                                         //�\�Z���ރt���O
        vo.setEXPCDFLG(cond.getExpcdflg());                                             //�\�Z�\��ڃt���O
        vo.setEXPENSEFLG(cond.getExpenseflg());                                         //��ڃt���O
        vo.setDETAILFLG(cond.getDetailflg());                                           //�ڍ׃t���O
        vo.setKIKANSFLG(cond.getKikansflg());                                           //���ԊJ�n�t���O
        vo.setKIKANEFLG(cond.getKikaneflg());                                           //���ԏI���t���O
        vo.setCONTRACTDATEFLG(cond.getContractdateflg());                               //�_��J�n�N�����t���O
        vo.setCONTRACTTERMFLG(cond.getContracttermflg());                               //�_�����(����)�t���O
        vo.setSEIKYUFLG(cond.getSeikyuflg());                                           //������t���O
        vo.setORDERNOFLG(cond.getOrdernoflg());                                         //��NO�t���O
        vo.setPAYFLG(cond.getPayflg());                                                 //�x����t���O
        vo.setUSERNAMEFLG(cond.getUsernameflg());                                       //�S���҃t���O
        vo.setGETMONEYFLG(cond.getGetmoneyflg());                                       //�����z�t���O
        vo.setGETCONFIRMFLG(cond.getGetconfirmflg());                                   //�����z�m�F�t���O
        vo.setPAYMONEYFLG(cond.getPaymoneyflg());                                       //�������z�t���O
        vo.setPAYCONFIRMFLG(cond.getPayconfirmflg());                                   //�������z�m�F�t���O
        vo.setESTMONEYFLG(cond.getEstmoneyflg());                                       //���ϋ��z�t���O
        vo.setCLMMONEYFLG(cond.getClmmoneyflg());                                       //�������z�t���O
        vo.setDELIVERDAYFLG(cond.getDeliverdayflg());                                   //�x����[�i���t���O
        vo.setSETMONTHFLG(cond.getSetmonthflg());                                       //�ݒ茎�t���O
        vo.setDIVISIONFLG(cond.getDivisionflg());                                       //�敪�t���O
        vo.setGROUPCDFLG(cond.getGroupcdflg());                                         //�O���[�v�R�[�h�t���O
        vo.setSTKYKNOFLG(cond.getStkyknoflg());                                         //�ݒ�ǃi���o�[�t���O
        vo.setEGTYKFLGFLG(cond.getEgtykflgflg());                                       //�c���`�F�b�N�t���O
        vo.setINPUTTNTCDFLG(cond.getInputtntcdflg());                                   //���͒S���R�[�h�t���O
        vo.setCPTNTNMFLG(cond.getCptntnmflg());                                         //CP�S���҃t���O
        vo.setNOTEFLG(cond.getNoteflg());                                               //���l�t���O
        vo.setDCARCDCONFFLG(cond.getDcarcdconfflg());                                   //�d�ʎԎ�R�[�h�m�F�t���O
        vo.setDCARCDCONFSIKCD(cond.getDcarcdconfsikcd());                               //�d�ʎԎ�R�[�h�m�F�g�D�R�[�h
        vo.setDCARCDCONFHAMID(cond.getDcarcdconfhamid());                               //�d�ʎԎ�R�[�h�m�F�S���҃R�[�h
        vo.setCLASSCDCONFFLG(cond.getClasscdconfflg());                                 //�\�Z�\���ފm�F�t���O
        vo.setCLASSCDCONFSIKCD(cond.getClasscdconfsikcd());                             //�\�Z�\���ފm�F�g�D�R�[�h
        vo.setCLASSCDCONFHAMID(cond.getClasscdconfhamid());                             //�\�Z�\���ފm�F�S���҃R�[�h
        vo.setEXPCDCONFFLG(cond.getExpcdconfflg());                                     //�\�Z�\��ڊm�F�t���O
        vo.setEXPCDCONFSIKCD(cond.getExpcdconfsikcd());                                 //�\�Z�\��ڊm�F�g�D�R�[�h
        vo.setEXPCDCONFHAMID(cond.getExpcdconfhamid());                                 //�\�Z�\��ڊm�F�S���҃R�[�h
        vo.setEXPENSECONFFLG(cond.getExpenseconfflg());                                 //��ڊm�F�t���O
        vo.setEXPENSECONFSIKCD(cond.getExpenseconfsikcd());                             //��ڊm�F�g�D�R�[�h
        vo.setEXPENSECONFHAMID(cond.getExpenseconfhamid());                             //��ڊm�F�S���҃R�[�h
        vo.setDETAILCONFFLG(cond.getDetailconfflg());                                   //�ڍ׊m�F�t���O
        vo.setDETAILCONFSIKCD(cond.getDetailconfsikcd());                               //�ڍ׊m�F�g�D�R�[�h
        vo.setDETAILCONFHAMID(cond.getDetailconfhamid());                               //�ڍ׊m�F�S���҃R�[�h
        vo.setKIKANSCONFFLG(cond.getKikansconfflg());                                   //���ԊJ�n�m�F�t���O
        vo.setKIKANSCONFSIKCD(cond.getKikansconfsikcd());                               //���ԊJ�n�m�F�g�D�R�[�h
        vo.setKIKANSCONFHAMID(cond.getKikansconfhamid());                               //���ԊJ�n�m�F�S���҃R�[�h
        vo.setKIKANECONFFLG(cond.getKikaneconfflg());                                   //���ԏI���m�F�t���O
        vo.setKIKANECONFSIKCD(cond.getKikaneconfsikcd());                               //���ԏI���m�F�g�D�R�[�h
        vo.setKIKANECONFHAMID(cond.getKikaneconfhamid());                               //���ԏI���m�F�S���҃R�[�h
        vo.setCONTRACTDATECONFFLG(cond.getContractdateconfflg());                       //�_��J�n�N�����m�F�t���O
        vo.setCONTRACTDATECONFSIKCD(cond.getContractdateconfsikcd());                   //�_��J�n�N�����m�F�g�D�R�[�h
        vo.setCONTRACTDATECONFHAMID(cond.getContractdateconfhamid());                   //�_��J�n�N�����m�F�S���҃R�[�h
        vo.setCONTRACTTERMCONFFLG(cond.getContracttermconfflg());                       //�_�����(����)�m�F�t���O
        vo.setCONTRACTTERMCONFSIKCD(cond.getContracttermconfsikcd());                   //�_�����(����)�m�F�g�D�R�[�h
        vo.setCONTRACTTERMCONFHAMID(cond.getContracttermconfhamid());                   //�_�����(����)�m�F�S���҃R�[�h
        vo.setSEIKYUCONFFLG(cond.getSeikyuconfflg());                                   //������m�F�t���O
        vo.setSEIKYUCONFSIKCD(cond.getSeikyuconfsikcd());                               //������m�F�g�D�R�[�h
        vo.setSEIKYUCONFHAMID(cond.getSeikyuconfhamid());                               //������m�F�S���҃R�[�h
        vo.setORDERNOCONFFLG(cond.getOrdernoconfflg());                                 //��NO�m�F�t���O
        vo.setORDERNOCONFSIKCD(cond.getOrdernoconfsikcd());                             //��NO�m�F�g�D�R�[�h
        vo.setORDERNOCONFHAMID(cond.getOrdernoconfhamid());                             //��NO�m�F�S���҃R�[�h
        vo.setPAYCONFFLG(cond.getPayconfflg());                                         //�x����m�F�t���O
        vo.setPAYCONFSIKCD(cond.getPayconfsikcd());                                     //�x����m�F�g�D�R�[�h
        vo.setPAYCONFHAMID(cond.getPayconfhamid());                                     //�x����m�F�S���҃R�[�h
        vo.setUSERNAMECONFFLG(cond.getUsernameconfflg());                               //�S���Ҋm�F�t���O
        vo.setUSERNAMECONFSIKCD(cond.getUsernameconfsikcd());                           //�S���Ҋm�F�g�D�R�[�h
        vo.setUSERNAMECONFHAMID(cond.getUsernameconfhamid());                           //�S���Ҋm�F�S���҃R�[�h
        vo.setGETMONEYCONFFLG(cond.getGetmoneyconfflg());                               //�����z�m�F�t���O
        vo.setGETMONEYCONFSIKCD(cond.getGetmoneyconfsikcd());                           //�����z�m�F�g�D�R�[�h
        vo.setGETMONEYCONFHAMID(cond.getGetmoneyconfhamid());                           //�����z�m�F�S���҃R�[�h
        vo.setGETCONFCONFFLG(cond.getGetconfconfflg());                                 //�����z�m�F�m�F�t���O
        vo.setGETCONFCONFSIKCD(cond.getGetconfconfsikcd());                             //�����z�m�F�m�F�g�D�R�[�h
        vo.setGETCONFCONFHAMID(cond.getGetconfconfhamid());                             //�����z�m�F�m�F�S���҃R�[�h
        vo.setPAYMONEYCONFFLG(cond.getPaymoneyconfflg());                               //�������z�m�F�t���O
        vo.setPAYMONEYCONFSIKCD(cond.getPaymoneyconfsikcd());                           //�������z�m�F�g�D�R�[�h
        vo.setPAYMONEYCONFHAMID(cond.getPaymoneyconfhamid());                           //�������z�m�F�S���҃R�[�h
        vo.setPAYCONFCONFFLG(cond.getPayconfconfflg());                                 //�������z�m�F�m�F�t���O
        vo.setPAYCONFCONFSIKCD(cond.getPayconfconfsikcd());                             //�������z�m�F�m�F�g�D�R�[�h
        vo.setPAYCONFCONFHAMID(cond.getPayconfconfhamid());                             //�������z�m�F�m�F�S���҃R�[�h
        vo.setESTMONEYCONFFLG(cond.getEstmoneyconfflg());                               //���ϋ��z�m�F�t���O
        vo.setESTMONEYCONFSIKCD(cond.getEstmoneyconfsikcd());                           //���ϋ��z�m�F�g�D�R�[�h
        vo.setESTMONEYCONFHAMID(cond.getEstmoneyconfhamid());                           //���ϋ��z�m�F�S���҃R�[�h
        vo.setCLMMONEYCONFFLG(cond.getClmmoneyconfflg());                               //�������z�m�F�t���O
        vo.setCLMMONEYCONFSIKCD(cond.getClmmoneyconfsikcd());                           //�������z�m�F�g�D�R�[�h
        vo.setCLMMONEYCONFHAMID(cond.getClmmoneyconfhamid());                           //�������z�m�F�S���҃R�[�h
        vo.setDELIVERDAYCONFFLG(cond.getDeliverdayconfflg());                           //�x����[�i���m�F�t���O
        vo.setDELIVERDAYCONFSIKCD(cond.getDeliverdayconfsikcd());                       //�x����[�i���m�F�g�D�R�[�h
        vo.setDELIVERDAYCONFHAMID(cond.getDeliverdayconfhamid());                       //�x����[�i���m�F�S���҃R�[�h
        vo.setSETMONTHCONFFLG(cond.getSetmonthconfflg());                               //�ݒ茎�m�F�t���O
        vo.setSETMONTHCONFSIKCD(cond.getSetmonthconfsikcd());                           //�ݒ茎�m�F�g�D�R�[�h
        vo.setSETMONTHCONFHAMID(cond.getSetmonthconfhamid());                           //�ݒ茎�m�F�S���҃R�[�h
        vo.setDIVISIONCONFFLG(cond.getDivisionconfflg());                               //�敪�R�[�h�m�F�t���O
        vo.setDIVISIONCONFSIKCD(cond.getDivisionconfsikcd());                           //�敪�R�[�h�m�F�g�D�R�[�h
        vo.setDIVISIONCONFHAMID(cond.getDivisionconfhamid());                           //�敪�R�[�h�m�F�S���҃R�[�h
        vo.setGROUPCDCONFFLG(cond.getGroupcdconfflg());                                 //�O���[�v�R�[�h�m�F�t���O
        vo.setGROUPCDCONFSIKCD(cond.getGroupcdconfsikcd());                             //�O���[�v�R�[�h�m�F�g�D�R�[�h
        vo.setGROUPCDCONFHAMID(cond.getGroupcdconfhamid());                             //�O���[�v�R�[�h�m�F�S���҃R�[�h
        vo.setSTKYKNOCONFFLG(cond.getStkyknoconfflg());                                 //�ݒ�ǃi���o�[�m�F�t���O
        vo.setSTKYKNOCONFSIKCD(cond.getStkyknoconfsikcd());                             //�ݒ�ǃi���o�[�m�F�g�D�R�[�h
        vo.setSTKYKNOCONFHAMID(cond.getStkyknoconfhamid());                             //�ݒ�ǃi���o�[�m�F�S���҃R�[�h
        vo.setEGTYKCONFFLG(cond.getEgtykconfflg());                                     //�c���`�F�b�N�m�F�t���O
        vo.setEGTYKCONFSIKCD(cond.getEgtykconfsikcd());                                 //�c���`�F�b�N�m�F�g�D�R�[�h
        vo.setEGTYKCONFHAMID(cond.getEgtykconfhamid());                                 //�c���`�F�b�N�m�F�S���҃R�[�h
        vo.setINPUTTNTCDCONFFLG(cond.getInputtntcdconfflg());                           //���͒S���R�[�h�m�F�t���O
        vo.setINPUTTNTCDCONFSIKCD(cond.getInputtntcdconfsikcd());                       //���͒S���R�[�h�m�F�g�D�R�[�h
        vo.setINPUTTNTCDCONFHAMID(cond.getInputtntcdconfhamid());                       //���͒S���R�[�h�m�F�S���҃R�[�h
        vo.setCPTNTNMCONFFLG(cond.getCptntnmconfflg());                                 //CP�S���Ҋm�F�t���O
        vo.setCPTNTNMCONFSIKCD(cond.getCptntnmconfsikcd());                             //CP�S���Ҋm�F�g�D�R�[�h
        vo.setCPTNTNMCONFHAMID(cond.getCptntnmconfhamid());                             //CP�S���Ҋm�F�S���҃R�[�h
        vo.setNOTECONFFLG(cond.getNoteconfflg());                                       //���l�m�F�t���O
        vo.setNOTECONFSIKCD(cond.getNoteconfsikcd());                                   //���l�m�F�g�D�R�[�h
        vo.setNOTECONFHAMID(cond.getNoteconfhamid());                                   //���l�m�F�S���҃R�[�h
        vo.setCRTDATE(cond.getCrtdate());                                               //�f�[�^�쐬����
        vo.setCRTNM(cond.getCrtnm());                                                   //�f�[�^�쐬��
        vo.setUPDDATE(cond.getUpddate());                                               //�f�[�^�X�V����
        vo.setUPDNM(cond.getUpdnm());                                                   //�f�[�^�X�V��
        vo.setUPDAPL(cond.getUpdapl());                                                 //�X�V�v���O����
        vo.setUPDID(cond.getUpdid());                                                   //�X�V�S����ID


        return vo;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()�Ŏg�p�����SELECT + FROM���SQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.COND)) {

            //*******************************************
            //selectVO�Ŏg�p�����SQL
            //*******************************************
            //SELECT + FROM��
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE��
            sql.append(generateWhereByCond(getModel()));
            //OrderBy��
            sql.append(" ORDER BY ");
            sql.append(" " + Tbj27LogCrCreateData.HISTORYNO + " ");

        }

        return sql.toString();
    };

    /**
     * �l�̐ݒ�L������SQL��WHERE��𐶐�����
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

//    /**
//     * �l�̐ݒ�L������UPDATE��SET��𐶐�����
//     * @param vo
//     * @return
//     */
//    private String generateSetByCond(AbstractModel vo) {
//        StringBuffer sql = new StringBuffer();
//
//        for (int i = 0; i < getTableColumnNames().length; i++) {
//            Object value = vo.get(getTableColumnNames()[i]);
//            if (value != null) {
//                if (sql.length() == 0) {
//                    sql.append(" SET ");
//                } else {
//                    sql.append("    ,");
//                }
//                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
//            }
//        }
//
//        return sql.toString();
//    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj27LogCrCreateDataVO> selectVO(Tbj27LogCrCreateDataCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj27LogCrCreateDataVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK����
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj27LogCrCreateDataVO loadVO(Tbj27LogCrCreateDataVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            return (Tbj27LogCrCreateDataVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
