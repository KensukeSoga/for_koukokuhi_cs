package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�����Ǘ�DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj11CrCreateDataDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj11CrCreateDataCondition _condition = null;
    private List<Tbj11CrCreateDataVO> _conditions = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{LOAD, COND, MAXSEQ, MAXTIME, MAXSORT, LOCK, };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /** getExecSQL�Ŕ��s����SQL�̃��[�h() */
    private enum ExecSqlMode{UPD, UPDSORT, };
    private ExecSqlMode _ExecSqlMode = ExecSqlMode.UPD;

    private enum StoreMode {INS, UPD, };
    private StoreMode _StoreMode = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj11CrCreateDataDAO() {
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
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj11CrCreateData.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (StoreMode.INS.equals(_StoreMode)) {
            return new String[] {
                    Tbj11CrCreateData.CRTDATE
                    ,Tbj11CrCreateData.UPDDATE
            };
        } else if (StoreMode.UPD.equals(_StoreMode)) {
            return new String[] {
                    Tbj11CrCreateData.UPDDATE
            };
        } else {
            return new String[] {};
        }
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj11CrCreateData.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj11CrCreateData.DCARCD
                ,Tbj11CrCreateData.PHASE
                ,Tbj11CrCreateData.CRDATE
                ,Tbj11CrCreateData.SEQUENCENO
                ,Tbj11CrCreateData.CLASSDIV
                ,Tbj11CrCreateData.SORTNO
                ,Tbj11CrCreateData.CLASSCD
                ,Tbj11CrCreateData.EXPCD
                ,Tbj11CrCreateData.EXPENSE
                ,Tbj11CrCreateData.DETAIL
                ,Tbj11CrCreateData.KIKANS
                ,Tbj11CrCreateData.KIKANE
                ,Tbj11CrCreateData.CONTRACTDATE
                ,Tbj11CrCreateData.CONTRACTTERM
                ,Tbj11CrCreateData.SEIKYU
                ,Tbj11CrCreateData.TRTHSKGYCD
                ,Tbj11CrCreateData.TRSEQNO
                ,Tbj11CrCreateData.ORDERNO
                ,Tbj11CrCreateData.PAY
                ,Tbj11CrCreateData.HRTHSKGYCD
                ,Tbj11CrCreateData.HRSEQNO
                ,Tbj11CrCreateData.USERNAME
                ,Tbj11CrCreateData.GETMONEY
                ,Tbj11CrCreateData.GETCONF
                ,Tbj11CrCreateData.PAYMONEY
                ,Tbj11CrCreateData.PAYCONF
                ,Tbj11CrCreateData.ESTMONEY
                ,Tbj11CrCreateData.CLMMONEY
                ,Tbj11CrCreateData.DELIVERDAY
                ,Tbj11CrCreateData.SETMONTH
                ,Tbj11CrCreateData.DIVCD
                ,Tbj11CrCreateData.GROUPCD
                ,Tbj11CrCreateData.STKYKNO
                ,Tbj11CrCreateData.STTNTID
                ,Tbj11CrCreateData.STTNTNM
                ,Tbj11CrCreateData.EGTYKFLG
                ,Tbj11CrCreateData.INPUTTNTCD
                ,Tbj11CrCreateData.CPTNTNM
                ,Tbj11CrCreateData.NOTE
                ,Tbj11CrCreateData.TCKEY
                ,Tbj11CrCreateData.TRSUBNO
                ,Tbj11CrCreateData.HRSUBNO
                ,Tbj11CrCreateData.RSTATUS
                ,Tbj11CrCreateData.STPKBN
                ,Tbj11CrCreateData.DCARCDFLG
                ,Tbj11CrCreateData.CLASSCDFLG
                ,Tbj11CrCreateData.EXPCDFLG
                ,Tbj11CrCreateData.EXPENSEFLG
                ,Tbj11CrCreateData.DETAILFLG
                ,Tbj11CrCreateData.KIKANSFLG
                ,Tbj11CrCreateData.KIKANEFLG
                ,Tbj11CrCreateData.CONTRACTDATEFLG
                ,Tbj11CrCreateData.CONTRACTTERMFLG
                ,Tbj11CrCreateData.SEIKYUFLG
                ,Tbj11CrCreateData.ORDERNOFLG
                ,Tbj11CrCreateData.PAYFLG
                ,Tbj11CrCreateData.USERNAMEFLG
                ,Tbj11CrCreateData.GETMONEYFLG
                ,Tbj11CrCreateData.GETCONFIRMFLG
                ,Tbj11CrCreateData.PAYMONEYFLG
                ,Tbj11CrCreateData.PAYCONFIRMFLG
                ,Tbj11CrCreateData.ESTMONEYFLG
                ,Tbj11CrCreateData.CLMMONEYFLG
                ,Tbj11CrCreateData.DELIVERDAYFLG
                ,Tbj11CrCreateData.SETMONTHFLG
                ,Tbj11CrCreateData.DIVISIONFLG
                ,Tbj11CrCreateData.GROUPCDFLG
                ,Tbj11CrCreateData.STKYKNOFLG
                ,Tbj11CrCreateData.STTNTNMFLG
                ,Tbj11CrCreateData.EGTYKFLGFLG
                ,Tbj11CrCreateData.INPUTTNTCDFLG
                ,Tbj11CrCreateData.CPTNTNMFLG
                ,Tbj11CrCreateData.NOTEFLG
                ,Tbj11CrCreateData.DCARCDCONFFLG
                ,Tbj11CrCreateData.DCARCDCONFSIKCD
                ,Tbj11CrCreateData.DCARCDCONFHAMID
                ,Tbj11CrCreateData.CLASSCDCONFFLG
                ,Tbj11CrCreateData.CLASSCDCONFSIKCD
                ,Tbj11CrCreateData.CLASSCDCONFHAMID
                ,Tbj11CrCreateData.EXPCDCONFFLG
                ,Tbj11CrCreateData.EXPCDCONFSIKCD
                ,Tbj11CrCreateData.EXPCDCONFHAMID
                ,Tbj11CrCreateData.EXPENSECONFFLG
                ,Tbj11CrCreateData.EXPENSECONFSIKCD
                ,Tbj11CrCreateData.EXPENSECONFHAMID
                ,Tbj11CrCreateData.DETAILCONFFLG
                ,Tbj11CrCreateData.DETAILCONFSIKCD
                ,Tbj11CrCreateData.DETAILCONFHAMID
                ,Tbj11CrCreateData.KIKANSCONFFLG
                ,Tbj11CrCreateData.KIKANSCONFSIKCD
                ,Tbj11CrCreateData.KIKANSCONFHAMID
                ,Tbj11CrCreateData.KIKANECONFFLG
                ,Tbj11CrCreateData.KIKANECONFSIKCD
                ,Tbj11CrCreateData.KIKANECONFHAMID
                ,Tbj11CrCreateData.CONTRACTDATECONFFLG
                ,Tbj11CrCreateData.CONTRACTDATECONFSIKCD
                ,Tbj11CrCreateData.CONTRACTDATECONFHAMID
                ,Tbj11CrCreateData.CONTRACTTERMCONFFLG
                ,Tbj11CrCreateData.CONTRACTTERMCONFSIKCD
                ,Tbj11CrCreateData.CONTRACTTERMCONFHAMID
                ,Tbj11CrCreateData.SEIKYUCONFFLG
                ,Tbj11CrCreateData.SEIKYUCONFSIKCD
                ,Tbj11CrCreateData.SEIKYUCONFHAMID
                ,Tbj11CrCreateData.ORDERNOCONFFLG
                ,Tbj11CrCreateData.ORDERNOCONFSIKCD
                ,Tbj11CrCreateData.ORDERNOCONFHAMID
                ,Tbj11CrCreateData.PAYCONFFLG
                ,Tbj11CrCreateData.PAYCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFHAMID
                ,Tbj11CrCreateData.USERNAMECONFFLG
                ,Tbj11CrCreateData.USERNAMECONFSIKCD
                ,Tbj11CrCreateData.USERNAMECONFHAMID
                ,Tbj11CrCreateData.GETMONEYCONFFLG
                ,Tbj11CrCreateData.GETMONEYCONFSIKCD
                ,Tbj11CrCreateData.GETMONEYCONFHAMID
                ,Tbj11CrCreateData.GETCONFCONFFLG
                ,Tbj11CrCreateData.GETCONFCONFSIKCD
                ,Tbj11CrCreateData.GETCONFCONFHAMID
                ,Tbj11CrCreateData.PAYMONEYCONFFLG
                ,Tbj11CrCreateData.PAYMONEYCONFSIKCD
                ,Tbj11CrCreateData.PAYMONEYCONFHAMID
                ,Tbj11CrCreateData.PAYCONFCONFFLG
                ,Tbj11CrCreateData.PAYCONFCONFSIKCD
                ,Tbj11CrCreateData.PAYCONFCONFHAMID
                ,Tbj11CrCreateData.ESTMONEYCONFFLG
                ,Tbj11CrCreateData.ESTMONEYCONFSIKCD
                ,Tbj11CrCreateData.ESTMONEYCONFHAMID
                ,Tbj11CrCreateData.CLMMONEYCONFFLG
                ,Tbj11CrCreateData.CLMMONEYCONFSIKCD
                ,Tbj11CrCreateData.CLMMONEYCONFHAMID
                ,Tbj11CrCreateData.DELIVERDAYCONFFLG
                ,Tbj11CrCreateData.DELIVERDAYCONFSIKCD
                ,Tbj11CrCreateData.DELIVERDAYCONFHAMID
                ,Tbj11CrCreateData.SETMONTHCONFFLG
                ,Tbj11CrCreateData.SETMONTHCONFSIKCD
                ,Tbj11CrCreateData.SETMONTHCONFHAMID
                ,Tbj11CrCreateData.DIVISIONCONFFLG
                ,Tbj11CrCreateData.DIVISIONCONFSIKCD
                ,Tbj11CrCreateData.DIVISIONCONFHAMID
                ,Tbj11CrCreateData.GROUPCDCONFFLG
                ,Tbj11CrCreateData.GROUPCDCONFSIKCD
                ,Tbj11CrCreateData.GROUPCDCONFHAMID
                ,Tbj11CrCreateData.STKYKNOCONFFLG
                ,Tbj11CrCreateData.STKYKNOCONFSIKCD
                ,Tbj11CrCreateData.STKYKNOCONFHAMID
                ,Tbj11CrCreateData.STTNTNMCONFFLG
                ,Tbj11CrCreateData.STTNTNMCONFSIKCD
                ,Tbj11CrCreateData.STTNTNMCONFHAMID
                ,Tbj11CrCreateData.EGTYKCONFFLG
                ,Tbj11CrCreateData.EGTYKCONFSIKCD
                ,Tbj11CrCreateData.EGTYKCONFHAMID
                ,Tbj11CrCreateData.INPUTTNTCDCONFFLG
                ,Tbj11CrCreateData.INPUTTNTCDCONFSIKCD
                ,Tbj11CrCreateData.INPUTTNTCDCONFHAMID
                ,Tbj11CrCreateData.CPTNTNMCONFFLG
                ,Tbj11CrCreateData.CPTNTNMCONFSIKCD
                ,Tbj11CrCreateData.CPTNTNMCONFHAMID
                ,Tbj11CrCreateData.NOTECONFFLG
                ,Tbj11CrCreateData.NOTECONFSIKCD
                ,Tbj11CrCreateData.NOTECONFHAMID
                ,Tbj11CrCreateData.CRTDATE
                ,Tbj11CrCreateData.CRTNM
                ,Tbj11CrCreateData.CRTAPL
                ,Tbj11CrCreateData.CRTID
                ,Tbj11CrCreateData.UPDDATE
                ,Tbj11CrCreateData.UPDNM
                ,Tbj11CrCreateData.UPDAPL
                ,Tbj11CrCreateData.UPDID
        };
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
            sql.append(" " + Tbj11CrCreateData.SORTNO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSEQ)) {

            //*******************************************
            //findMaxSeqNo�Ŏg�p�����SQL
            //*******************************************
            //SELECT + FROM��
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj11CrCreateData.SEQUENCENO  + "), 0) AS " + Tbj11CrCreateData.SEQUENCENO + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj11CrCreateData.TBNAME + " ");
            //WHERE��
            sql.append(generateWhereByCond(convertCondToVo(_condition)));
//            sql.append(" WHERE ");
//            sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + getDBModelInterface().ConvertToDBString(_condition.getDcarcd()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + getDBModelInterface().ConvertToDBString(_condition.getPhase()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.CRDATE + " = " + getDBModelInterface().ConvertToDBString(_condition.getCrdate()) + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSORT)) {

            //*******************************************
            //findMaxSortNo�Ŏg�p�����SQL
            //*******************************************
            //SELECT + FROM��
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj11CrCreateData.SORTNO  + "), 0) AS " + Tbj11CrCreateData.SORTNO + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj11CrCreateData.TBNAME + " ");
            //WHERE��
            sql.append(generateWhereByCond(convertCondToVo(_condition)));
//            sql.append(" WHERE ");
//            sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + getDBModelInterface().ConvertToDBString(_condition.getDcarcd()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + getDBModelInterface().ConvertToDBString(_condition.getPhase()) + " ");
//            sql.append(" AND " + Tbj11CrCreateData.CRDATE + " = " + getDBModelInterface().ConvertToDBString(_condition.getCrdate()) + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXTIME)) {

            // *******************************************
            // findMaxTimeStamp�Ŏg�p�����SQL
            // *******************************************
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + getTimeStampKeyName() + "), SYSDATE) AS " + getTimeStampKeyName() + " ");
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE��
            sql.append(generateWhereByCond(getModel()));

        } else if (_SelSqlMode.equals(SelSqlMode.LOCK)) {

            // *******************************************
            // �r���pSQL
            // *******************************************
            sql.append(" SELECT ");
            sql.append(" " + getTimeStampKeyName() + " ");
            for (int i = 0; i < getPrimryKeyNames().length; i++) {
                sql.append(" ," + getPrimryKeyNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            sql.append(" WHERE ");
            for (int i = 0; i < _conditions.size(); i++) {
                AbstractModel cond = _conditions.get(i);
                sql.append((i != 0 ? " OR " : " "));
                sql.append(" ( ");
                for (int j = 0; j < getPrimryKeyNames().length; j++) {
                    sql.append((j != 0 ? " AND " : " "));
                    sql.append("" + getPrimryKeyNames()[j] +" ");
                    sql.append(" = ");
                    sql.append(ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
                }
                sql.append(" ) ");
            }
            sql.append(" FOR UPDATE NOWAIT ");
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
                sql.append(getTableColumnNames()[i] + " = " + ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * �l�̐ݒ�L������UPDATE��SET��𐶐�����
     * @param vo
     * @return
     */
    private String generateSetByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            String columnName = getTableColumnNames()[i];
            Object value = vo.get(columnName);
            if (getTimeStampKeyName().equals(columnName)) {
                //�V�X�e�����t�ōX�V���鍀�ڂ̏ꍇ�͒l�̗L���Ɋ֌W�Ȃ�SYSDATE�ōX�V
                if (sql.length() == 0) {
                    sql.append(" SET ");
                } else {
                    sql.append("    ,");
                }
                sql.append(columnName + " = " + getDBModelInterface().getSystemDateString());
            } else {
                if (value != null) {
                //if (vo.getUpdateMember().containsKey(columnName)) {
                    if (sql.length() == 0) {
                        sql.append(" SET ");
                    } else {
                        sql.append("    ,");
                    }
                    if (value != null) {
                        sql.append(columnName + " = " + ConvertToDBString(value));
                    }
                }
            }
        }

        return sql.toString();
    }

    /**
     * Condtion����VO�ɕϊ�����
     * @param cond
     * @return
     */
    private Tbj11CrCreateDataVO convertCondToVo(Tbj11CrCreateDataCondition cond) {
        Tbj11CrCreateDataVO vo = new Tbj11CrCreateDataVO();

        vo.setDCARCD(cond.getDcarcd());                                                 //�d�ʎԎ�R�[�h
        vo.setPHASE(cond.getPhase());                                                   //�t�F�C�Y
        vo.setCRDATE(cond.getCrdate());                                                 //�N��
        vo.setSEQUENCENO(cond.getSequenceno());                                         //�����Ǘ�NO
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
        vo.setORDERNO(cond.getOrderno());                                               //��NO
        vo.setPAY(cond.getPay());                                                       //�x����
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
        vo.setSTKYKNOFLG(cond.getStkyknoflg());                                         //�ݒ�ǃR�[�h�t���O
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
     * SEQUENCENO�̌��݂̍ő�l���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> findMaxSeqNo(Tbj11CrCreateDataCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSEQ;
            _condition = cond;
            return (List<Tbj11CrCreateDataVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SORTNO�̌��݂̍ő�l���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> findMaxSortNo(Tbj11CrCreateDataCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSORT;
            _condition = cond;
            return (List<Tbj11CrCreateDataVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * TIMESTAMP���ڂ̌��݂̍ő�l���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> findMaxTimeStamp(Tbj11CrCreateDataCondition cond) throws HAMException {
        // �p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.MAXTIME;
            _condition = cond;
            return (List<Tbj11CrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK�������ɂ��Č������s���܂�(�����w���)
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj11CrCreateDataVO> selectByPkWithLock(List<Tbj11CrCreateDataVO> cond) throws HAMException {
        // �p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj11CrCreateDataVO());
        try {
            _SelSqlMode = SelSqlMode.LOCK;
            _conditions = cond;
            return (List<Tbj11CrCreateDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    //public List<Tbj11CrCreateDataVO> selectVO(Tbj11CrCreateDataCondition cond) throws HAMException {
    public List<Tbj11CrCreateDataVO> selectVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj11CrCreateDataVO>)super.find();
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
    public Tbj11CrCreateDataVO loadVO(Tbj11CrCreateDataVO cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj11CrCreateDataVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    //�X�V�n����������������������������������������������������������������������������������������������������������������������������������������

    /**
     * �o�^
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean insertVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.INS;
            return super.insert();
        } catch (ConcurrentUpdateException e) {
            //����������0���̏ꍇ.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * PK�X�V
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean updateVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.UPD;
            return super.update();
        } catch (ConcurrentUpdateException e) {
            //����������0���̏ꍇ.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK�폜
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean deleteVO(Tbj11CrCreateDataVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            return super.remove();
        } catch (ConcurrentUpdateException e) {
            //����������0���̏ꍇ.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    @Override
    public String getExecString() {
        String sql = "";

        if (_ExecSqlMode.equals(ExecSqlMode.UPD)) {
            sql = getExecStringForUPD();
        } else {
            sql = getExecStringForUPDSORT();
        }

        return sql.toString();
    }

    /**
     * CR�����Ǘ��X�VSQL���擾����
     * @return
     */
    private String getExecStringForUPD() {
        StringBuffer sql = new StringBuffer();

        sql.append(" UPDATE ");
        sql.append("     " + getTableName() + " ");
        //SET��---------------------------------------------------------------------------------------------------------
        sql.append(generateSetByCond(getModel()));
        //WHERE��-------------------------------------------------------------------------------------------------------
        sql.append(generateWhereByCond(convertCondToVo(_condition)));

        return sql.toString();
    }

    /**
     * CR�����Ǘ�.�\�[�gNo�X�VSQL���擾����
     * @return
     */
    private String getExecStringForUPDSORT() {
        StringBuffer sql = new StringBuffer();

        Tbj11CrCreateDataVO vo = (Tbj11CrCreateDataVO) getModel();

        sql.append(" UPDATE ");
        sql.append("     " + Tbj11CrCreateData.TBNAME);
        sql.append(" SET ");
        sql.append("     " + Tbj11CrCreateData.SORTNO + " = " + ConvertToDBString(vo.getSORTNO()));
        sql.append(" WHERE ");
        sql.append("     " + Tbj11CrCreateData.DCARCD + " = " + ConvertToDBString(vo.getDCARCD()));
        sql.append(" AND " + Tbj11CrCreateData.PHASE + " = " + ConvertToDBString(vo.getPHASE()));
        sql.append(" AND " + Tbj11CrCreateData.CRDATE + " = " + ConvertToDBString(vo.getCRDATE()));
        sql.append(" AND " + Tbj11CrCreateData.SEQUENCENO + " = " + ConvertToDBString(vo.getSEQUENCENO()));

        return sql.toString();
    }

    /**
     * Condition�Ŏw�肵�������AVO�̓��e�ōX�V����
     * @param vo
     * @param cond
     * @throws HAMException
     */
    public void updateVOByCond(Tbj11CrCreateDataVO vo, Tbj11CrCreateDataCondition cond) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);
        _condition = cond;
        try {
            _StoreMode = StoreMode.UPD;
            _ExecSqlMode = ExecSqlMode.UPD;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * �\�[�gNo���X�V����
     * @param vo
     * @throws HAMException
     */
    public void updateSortNo(Tbj11CrCreateDataVO vo) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            _StoreMode = StoreMode.UPD;
            _ExecSqlMode = ExecSqlMode.UPDSORT;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    private String ConvertToDBString(Object obj) {
        return super.getDBModelInterface().ConvertToDBString(obj);
    }
}
