package jp.co.isid.ham.production.model;

import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class DataMoveDAO extends AbstractSimpleRdbDao {

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public DataMoveDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        return sql.toString();
    };

//    /**
//     * ��ʂŎw�肵�������Ō������s���A�ꗗ�ɕ\������f�[�^���擾���܂�
//     *
//     * @param cond
//     * @return
//     * @throws HAMException
//     */
//    @SuppressWarnings("unchecked")
//    public List<Tbj11CrCreateDataVO> updateForMoveData(FindCrCreateDataCondition cond) throws HAMException {
//        //�p�����[�^�`�F�b�N
//        if (cond == null) {
//            throw new HAMException("�����G���[", "BJ-E0001");
//        }
//        super.setModel(new Tbj11CrCreateDataVO());
//        try {
////            _SelSqlMode = SelSqlMode.LIST;
//            _moveCrCreateData = cond;
//            return (List<Tbj11CrCreateDataVO>) super.find();
//        } catch (UserException e) {
//            throw new HAMException(e.getMessage(), "BJ-E0001");
//        }
//    }

    ///**
    //* Model�̐������s��<br>
    //* �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
    //* AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
    //*
    //* @param hashList List ��������
    //* @return List<CommonCodeMasterVO> �ϊ���̌�������
    //*/
    //@Override
    //@SuppressWarnings("unchecked")
    //protected List createFindedModelInstances(List hashList) {
    //List list = null;
    //if (getModel() instanceof MaterialRegisterCntrctVO) {
    //list = new ArrayList<MaterialRegisterCntrctVO>();
    //for (int i = 0; i < hashList.size(); i++) {
    //Map result = (Map) hashList.get(i);
    //MaterialRegisterCntrctVO vo = new MaterialRegisterCntrctVO();
    //vo.setCMCD((String)result.get(Tbj17Content.CMCD.toUpperCase()));
    //vo.setCTRTKBN((String)result.get(Tbj16ContractInfo.CTRTKBN.toUpperCase()));
    //vo.setCTRTNO((String)result.get(Tbj16ContractInfo.CTRTNO.toUpperCase()));
    //vo.setNAMES((String)result.get(Tbj16ContractInfo.NAMES.toUpperCase()));
    //vo.setDATEFROM(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATEFROM.toUpperCase())));
    //vo.setDATETO(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATETO.toUpperCase())));
    //vo.setMUSIC((String)result.get(Tbj16ContractInfo.MUSIC.toUpperCase()));
    //vo.setSALEFLG((String)result.get(Tbj16ContractInfo.SALEFLG.toUpperCase()));
    //vo.setCRTDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.CRTDATE.toUpperCase())));
    //vo.setUPDDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.UPDDATE.toUpperCase())));
    //vo.setUPDNM((String)result.get(Tbj16ContractInfo.UPDNM.toUpperCase()));
    //vo.setUPDAPL((String)result.get(Tbj16ContractInfo.UPDAPL.toUpperCase()));
    //vo.setUPDID((String)result.get(Tbj16ContractInfo.UPDID.toUpperCase()));
    //vo.setDCARCD((String)result.get(Tbj16ContractInfo.DCARCD.toUpperCase()));
    //vo.setCATEGORY((String)result.get(Tbj16ContractInfo.CATEGORY.toUpperCase()));
    //vo.setJASRACFLG((String)result.get(Tbj16ContractInfo.JASRACFLG.toUpperCase()));
    //
    //// �������ʒ���̏�Ԃɂ���
    //ModelUtils.copyMemberSearchAfterInstace(vo);
    //list.add(vo);
    //}
    //}
    //return list;
    //}

    //�X�V�n����������������������������������������������������������������������������������������������������������������

    /**
     * Exec()�Ŏ��s�����f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getExecString() {
        StringBuffer sql = new StringBuffer();

        sql.append(" UPDATE ");
        sql.append("     " + Tbj11CrCreateData.TBNAME );
        sql.append(" SET ");
        sql.append("     " + Tbj11CrCreateData.PHASE + "       = " + ConvertToDBString(""));// �t�F�C�Y
        sql.append("     " + Tbj11CrCreateData.CRDATE + "      = " + ConvertToDBString(""));// �N��
        sql.append("     " + Tbj11CrCreateData.CLASSDIV + "    = " + ConvertToDBString(""));// �f�[�^���
        sql.append("     " + Tbj11CrCreateData.DCARCD + "      = " + ConvertToDBString(""));// �d�ʎԎ�R�[�h
        sql.append("     " + Tbj11CrCreateData.SORTNO + "      = " + ConvertToDBString(""));// �\�[�gNo
        sql.append("     " + Tbj11CrCreateData.DIVCD + "       = " + ConvertToDBString(""));// �\�Z�\���ރR�[�h
        sql.append("     " + Tbj11CrCreateData.KIKANS + "      = " + ConvertToDBString(""));// ����From
        sql.append("     " + Tbj11CrCreateData.KIKANE + "      = " + ConvertToDBString(""));// ����To
        sql.append("     " + Tbj11CrCreateData.SEIKYU + "      = " + ConvertToDBString(""));// ������
        sql.append("     " + Tbj11CrCreateData.GETMONEY + "    = " + ConvertToDBString(""));// �����z
        sql.append("     " + Tbj11CrCreateData.GETCONF + "     = " + ConvertToDBString(""));// �����z�m�F
        sql.append("     " + Tbj11CrCreateData.PAYMONEY + "    = " + ConvertToDBString(""));// �������z
        sql.append("     " + Tbj11CrCreateData.PAYCONF + "     = " + ConvertToDBString(""));// �������z�m�F
        sql.append("     " + Tbj11CrCreateData.ESTMONEY + "    = " + ConvertToDBString(""));// ���ϋ��z
        sql.append("     " + Tbj11CrCreateData.CLMMONEY + "    = " + ConvertToDBString(""));// �������z
        sql.append("     " + Tbj11CrCreateData.CLASSCD + "     = " + ConvertToDBString(""));// �\�Z���ރt���O
        sql.append("     " + Tbj11CrCreateData.KIKANSFLG + "   = " + ConvertToDBString(""));// ����From�t���O
        sql.append("     " + Tbj11CrCreateData.KIKANEFLG + "   = " + ConvertToDBString(""));// ����To�t���O
        sql.append("     " + Tbj11CrCreateData.SEIKYUFLG + "   = " + ConvertToDBString(""));// ������t���O
        sql.append("     " + Tbj11CrCreateData.GETMONEYFLG + " = " + ConvertToDBString(""));// �����z�t���O
        sql.append("     " + Tbj11CrCreateData.PAYMONEYFLG + " = " + ConvertToDBString(""));// �������z�t���O
        sql.append("     " + Tbj11CrCreateData.ESTMONEYFLG + " = " + ConvertToDBString(""));// ���ϋ��z�t���O
        sql.append("     " + Tbj11CrCreateData.CLMMONEYFLG + " = " + ConvertToDBString(""));// �������z�t���O
        sql.append("     " + Tbj11CrCreateData.INPUTTNTCD + "  = " + ConvertToDBString(""));// ���͒S��
        sql.append("     " + Tbj11CrCreateData.UPDDATE + "     = " + ConvertToDBString(""));// �f�[�^�X�V����
        sql.append("     " + Tbj11CrCreateData.UPDNM + "       = " + ConvertToDBString(""));// �f�[�^�X�V��
        sql.append("     " + Tbj11CrCreateData.UPDAPL + "      = " + ConvertToDBString(""));// �X�V�v���O����
        sql.append("     " + Tbj11CrCreateData.UPDID + "       = " + ConvertToDBString(""));// �X�V�S����ID
        sql.append(" WHERE ");
        sql.append("     " + Tbj11CrCreateData.DCARCD + "      = " + ConvertToDBString(""));// �d�ʎԎ�R�[�h
        sql.append(" AND ");
        sql.append("     " + Tbj11CrCreateData.PHASE + "       = " + ConvertToDBString(""));// �t�F�C�Y
        sql.append(" AND ");
        sql.append("     " + Tbj11CrCreateData.CRDATE + "      = " + ConvertToDBString(""));// �N��
        sql.append(" AND ");
        sql.append("     " + Tbj11CrCreateData.SEQUENCENO + "  = " + ConvertToDBString(""));// �����SEQNO






        return sql.toString();
    }
    //�X�V�n����������������������������������������������������������������������������������������������������������������

    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

}
