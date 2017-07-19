package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj10CrCarInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�Ԏ���w�b�_DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj10CrCarInfoDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private Tbj10CrCarInfoCondition _condition = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{LOAD, COND, MAXTIME, };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj10CrCarInfoDAO() {
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
                Tbj10CrCarInfo.DCARCD
                ,Tbj10CrCarInfo.PHASE
                ,Tbj10CrCarInfo.CRDATE
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj10CrCarInfo.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj10CrCarInfo.CRTDATE
                ,Tbj10CrCarInfo.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj10CrCarInfo.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj10CrCarInfo.DCARCD
                ,Tbj10CrCarInfo.PHASE
                ,Tbj10CrCarInfo.CRDATE
                ,Tbj10CrCarInfo.RAP
                ,Tbj10CrCarInfo.CPUSER
                ,Tbj10CrCarInfo.CDSTAFF
                ,Tbj10CrCarInfo.CRCOMPANY
                ,Tbj10CrCarInfo.SCHEDULE1
                ,Tbj10CrCarInfo.SCHEDULE2
                ,Tbj10CrCarInfo.SCHEDULE3
                ,Tbj10CrCarInfo.NOTE
                ,Tbj10CrCarInfo.CRTDATE
                ,Tbj10CrCarInfo.CRTNM
                ,Tbj10CrCarInfo.CRTAPL
                ,Tbj10CrCarInfo.CRTID
                ,Tbj10CrCarInfo.UPDDATE
                ,Tbj10CrCarInfo.UPDNM
                ,Tbj10CrCarInfo.UPDAPL
                ,Tbj10CrCarInfo.UPDID
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
     * Condtion����VO�ɕϊ�����
     * @param cond
     * @return
     */
    private Tbj10CrCarInfoVO convertCondToVo(Tbj10CrCarInfoCondition cond) {
        Tbj10CrCarInfoVO vo = new Tbj10CrCarInfoVO();

        vo.setCDSTAFF(cond.getCdstaff());
        vo.setCPUSER(cond.getCpuser());
        vo.setCRCOMPANY(cond.getCrcompany());
        vo.setCRDATE(cond.getCrdate());
        vo.setCRTDATE(cond.getCrtdate());
        vo.setCRTNM(cond.getCrtnm());
        vo.setDCARCD(cond.getDcarcd());
        vo.setNOTE(cond.getNote());
        vo.setPHASE(cond.getPhase());
        vo.setRAP(cond.getRap());
        vo.setSCHEDULE1(cond.getSchedule1());
        vo.setSCHEDULE2(cond.getSchedule2());
        vo.setSCHEDULE3(cond.getSchedule3());
        vo.setUPDAPL(cond.getUpdapl());
        vo.setUPDDATE(cond.getUpddate());
        vo.setUPDID(cond.getUpdid());
        vo.setUPDNM(cond.getUpdnm());

        return vo;
    }

    /**
     * TIMESTAMP���ڂ̌��݂̍ő�l���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj10CrCarInfoVO> findMaxTimeStamp(Tbj10CrCarInfoCondition cond) throws HAMException {
        // �p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.MAXTIME;
//            _condition = cond;
            return (List<Tbj10CrCarInfoVO>) super.find();
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
    //public List<Tbj10CrCarInfoVO> selectVO(Tbj10CrCarInfoCondition cond) throws HAMException {
    public List<Tbj10CrCarInfoVO> selectVO(Tbj10CrCarInfoVO vo) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj10CrCarInfoVO>)super.find();
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
    public Tbj10CrCarInfoVO loadVO(Tbj10CrCarInfoVO cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj10CrCarInfoVO)super.load();
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
    public void insertVO(Tbj10CrCarInfoVO vo) throws HAMException {
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
    public void updateVO(Tbj10CrCarInfoVO vo) throws HAMException {
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
    public void deleteVO(Tbj10CrCarInfoVO vo) throws HAMException {
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

}
