package jp.co.isid.ham.common.model;

import java.util.List;
import jp.co.isid.ham.integ.tbl.Tbj24LogContractInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �_����ύX���ODAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * �EHDX�Ή�(2016/03/01 K.Oki)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj24LogContractInfoDAO extends AbstractSimpleRdbDao {

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode{LOAD, MAX, };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj24LogContractInfoDAO() {
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
                Tbj24LogContractInfo.CTRTKBN
                , Tbj24LogContractInfo.CTRTNO
                , Tbj24LogContractInfo.HISTORYNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj24LogContractInfo.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj24LogContractInfo.CRTDATE
                , Tbj24LogContractInfo.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj24LogContractInfo.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj24LogContractInfo.HISTORYKEY
                , Tbj24LogContractInfo.HISTORYNO
                , Tbj24LogContractInfo.HISTORYKBN
                , Tbj24LogContractInfo.CTRTKBN
                , Tbj24LogContractInfo.CTRTNO
                , Tbj24LogContractInfo.DCARCD
                , Tbj24LogContractInfo.CATEGORY
                , Tbj24LogContractInfo.DELFLG
                , Tbj24LogContractInfo.NAMES
                , Tbj24LogContractInfo.DATEFROM
                , Tbj24LogContractInfo.DATETO
                , Tbj24LogContractInfo.MUSIC
                , Tbj24LogContractInfo.JASRACFLG
                , Tbj24LogContractInfo.SALEFLG
                /* 2016/03/01 HDX�Ή� HLC K.Oki ADD Start */
                , Tbj24LogContractInfo.ENDTITLEFLG
                , Tbj24LogContractInfo.ARRGORGFLG
                /* 2016/03/01 HDX�Ή� HLC K.Oki ADD End */
                , Tbj24LogContractInfo.BIKO
                , Tbj24LogContractInfo.CRTDATE
                , Tbj24LogContractInfo.CRTNM
                , Tbj24LogContractInfo.CRTAPL
                , Tbj24LogContractInfo.CRTID
                , Tbj24LogContractInfo.UPDDATE
                , Tbj24LogContractInfo.UPDNM
                , Tbj24LogContractInfo.UPDAPL
                , Tbj24LogContractInfo.UPDID
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

        } else if (_SelSqlMode.equals(SelSqlMode.MAX)) {

            //*******************************************
            //findMax�Ŏg�p�����SQL
            //*******************************************
            //SELECT + FROM��
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj24LogContractInfo.HISTORYKEY  + "), 0) AS " + Tbj24LogContractInfo.HISTORYKEY + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj24LogContractInfo.TBNAME + " ");

        }

        return sql.toString();
    };

    /**
     * PK����
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj24LogContractInfoVO loadVO(Tbj24LogContractInfoVO cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            _SelSqlMode = SelSqlMode.LOAD;
            return (Tbj24LogContractInfoVO)super.load();
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
    public void insertVO(Tbj24LogContractInfoVO vo) throws HAMException {
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
     * HISTORYKEY�̌��݂̍ő�l���擾���܂�
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj24LogContractInfoVO> findMax(Tbj24LogContractInfoCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj24LogContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.MAX;
            return (List<Tbj24LogContractInfoVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK�X�V
     * @param vo
     * @return
     * @throws HAMException
     */
    public void updateVO(Tbj24LogContractInfoVO vo) throws HAMException {
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
    public void deleteVO(Tbj24LogContractInfoVO vo) throws HAMException {
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
