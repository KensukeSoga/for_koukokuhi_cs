package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �_����DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * �EHDX�Ή�(2016/02/25 HLC K.Oki)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj16ContractInfoDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private List<Tbj16ContractInfoVO> _conditions = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{LOAD, COND, MAXHIS, LOCK, LIST, CATEGORY };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj16ContractInfoDAO() {
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
                Tbj16ContractInfo.CTRTKBN
                ,Tbj16ContractInfo.CTRTNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj16ContractInfo.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj16ContractInfo.CRTDATE
                ,Tbj16ContractInfo.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj16ContractInfo.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj16ContractInfo.CTRTKBN
                ,Tbj16ContractInfo.CTRTNO
                ,Tbj16ContractInfo.DCARCD
                ,Tbj16ContractInfo.CATEGORY
                ,Tbj16ContractInfo.DELFLG
                ,Tbj16ContractInfo.NAMES
                ,Tbj16ContractInfo.DATEFROM
                ,Tbj16ContractInfo.DATETO
                ,Tbj16ContractInfo.MUSIC
                ,Tbj16ContractInfo.JASRACFLG
                ,Tbj16ContractInfo.SALEFLG
                /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
                ,Tbj16ContractInfo.ENDTITLEFLG
                ,Tbj16ContractInfo.ARRGORGFLG
                /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */
                ,Tbj16ContractInfo.BIKO
                ,Tbj16ContractInfo.HISTORYKEY
                ,Tbj16ContractInfo.CRTDATE
                ,Tbj16ContractInfo.CRTNM
                ,Tbj16ContractInfo.CRTAPL
                ,Tbj16ContractInfo.CRTID
                ,Tbj16ContractInfo.UPDDATE
                ,Tbj16ContractInfo.UPDNM
                ,Tbj16ContractInfo.UPDAPL
                ,Tbj16ContractInfo.UPDID
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
            sql.append(" ORDER BY ");
            sql.append(" " + Tbj16ContractInfo.DATETO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.LIST)) {

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
            sql.append(" ORDER BY ");
            sql.append("  " + Tbj16ContractInfo.CRTDATE + " ");
            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXHIS)) {

            //*******************************************
            //findMax�Ŏg�p�����SQL
            //*******************************************
            //SELECT + FROM��
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj16ContractInfo.HISTORYKEY  + "), 0) AS " + Tbj16ContractInfo.HISTORYKEY + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj16ContractInfo.TBNAME + " ");

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
                    sql.append(getDBModelInterface().ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
                }
                sql.append(" ) ");
            }

        } else if (_SelSqlMode.equals(SelSqlMode.CATEGORY)) {

            sql.append(" SELECT ");
            sql.append("    " + Tbj16ContractInfo.CATEGORY + " ");
            sql.append(" FROM ");
            sql.append("    " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" GROUP BY ");
            sql.append("    " + Tbj16ContractInfo.CATEGORY + " ");
            sql.append(" ORDER BY ");
            sql.append("    MIN(" + Tbj16ContractInfo.CRTDATE + ") ");

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

    /**
     * Condition����VO�ɕϊ�����
     * @param cond
     * @return
     */
    private Tbj16ContractInfoVO convertCondToVo(Tbj16ContractInfoCondition cond) {
        Tbj16ContractInfoVO vo = new Tbj16ContractInfoVO();

        vo.setCTRTKBN(cond.getCtrtkbn());
        vo.setCTRTNO(cond.getCtrtno());
        vo.setDCARCD(cond.getDcarcd());
        vo.setCATEGORY(cond.getCategory());
        vo.setDELFLG(cond.getDelflg());
        vo.setNAMES(cond.getNames());
        vo.setDATEFROM(cond.getDatefrom());
        vo.setDATETO(cond.getDateto());
        vo.setMUSIC(cond.getMusic());
        vo.setJASRACFLG(cond.getJasracflg());
        vo.setSALEFLG(cond.getSaleflg());
        /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
        vo.setENDTITLEFLG(cond.getEndtitleflg());
        vo.setARRGORGFLG(cond.getArrgorgflg());
        /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */
        vo.setBIKO(cond.getBiko());
        vo.setCRTDATE(cond.getCrtdate());
        vo.setCRTNM(cond.getCrtnm());
        vo.setCRTAPL(cond.getCrtapl());
        vo.setCRTID(cond.getCrtid());
        vo.setUPDDATE(cond.getUpddate());
        vo.setUPDNM(cond.getUpdnm());
        vo.setUPDAPL(cond.getUpdapl());
        vo.setUPDID(cond.getUpdid());

        return vo;
    }

    /**
     * PK�������ɂ��Č������s���܂�(�����w���)
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj16ContractInfoVO> selectByPkWithLock(List<Tbj16ContractInfoVO> cond) throws HAMException {
        // �p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.LOCK;
            _conditions = cond;
            return (List<Tbj16ContractInfoVO>) super.find();
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
    public List<Tbj16ContractInfoVO> selectVO(Tbj16ContractInfoCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj16ContractInfoVO>)super.find();
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
    public List<Tbj16ContractInfoVO> selectVOForLIST(Tbj16ContractInfoCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.LIST;
            return (List<Tbj16ContractInfoVO>)super.find();
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
    public Tbj16ContractInfoVO loadVO(Tbj16ContractInfoVO cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj16ContractInfoVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �o�^
     * @param vo
     * @return
     * @throws HAMException
     */
    public void insertVO(Tbj16ContractInfoVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
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
    public void updateVO(Tbj16ContractInfoVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            super.update();
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
    public void deleteVO(Tbj16ContractInfoVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * HISTORYKEY�̌��݂̍ő�l���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj16ContractInfoVO> findMax(Tbj16ContractInfoCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.MAXHIS;
            return (List<Tbj16ContractInfoVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �J�e�S�����擾���܂�
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj16ContractInfoVO> getCategory() throws HAMException {
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.CATEGORY;
            return (List<Tbj16ContractInfoVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
