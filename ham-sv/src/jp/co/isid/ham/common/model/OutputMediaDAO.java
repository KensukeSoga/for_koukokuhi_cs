package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj14MediaOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �}�̏o�͐ݒ�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class OutputMediaDAO extends AbstractSimpleRdbDao{

    /** �������� */
    private FindExcelOutSettingCondition _cond = null;
    private String _searchMedia;

    private enum SqlMode{DEFAULT,REPORTOUT};
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public OutputMediaDAO() {
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
        return null;
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj14MediaOutCtrl.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj14MediaOutCtrl.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj14MediaOutCtrl.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj14MediaOutCtrl.REPORTCD
                ,Mbj14MediaOutCtrl.MEDIACD
                ,Mbj03Media.MEDIANM
                ,Mbj14MediaOutCtrl.OUTPUTFLG
                ,Mbj14MediaOutCtrl.SORTNO
                ,Mbj03Media.SORTNO
                ,Mbj14MediaOutCtrl.PHASE
                ,Mbj14MediaOutCtrl.UPDDATE
                ,Mbj14MediaOutCtrl.UPDNM
                ,Mbj14MediaOutCtrl.UPDAPL
                ,Mbj14MediaOutCtrl.UPDID
        };
    }


    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            return getOutputMediaList();
        } else if (_sqlMode.equals(SqlMode.REPORTOUT)) {
            return getOutputReportMediaList();
        } else {
            return null;
        }
    }


    /**
     * �Ԏ큕������SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getOutputMediaList() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" "+ Mbj14MediaOutCtrl.TBNAME + ", ");
        sql.append(" "+ Mbj03Media.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj14MediaOutCtrl.MEDIACD+ " = " + Mbj03Media.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj14MediaOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj14MediaOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj14MediaOutCtrl.OUTPUTFLG + " = 1 ");
        sql.append(" ORDER BY ");
        sql.append(" "+ Mbj14MediaOutCtrl.OUTPUTFLG + " ASC, ");
        sql.append(" "+ Mbj14MediaOutCtrl.SORTNO + " ASC, ");
        sql.append(" " + Mbj03Media.SORTNO + " ASC ");

        return sql.toString();
    }

    /**
     * �Ԏ큕������SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getOutputReportMediaList() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + Mbj14MediaOutCtrl.TBNAME + ", ");
        sql.append(" " + Mbj03Media.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj14MediaOutCtrl.MEDIACD+ " = " + Mbj03Media.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.OUTPUTFLG + " = 1 ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.MEDIACD + " IN(" + _searchMedia + ") ");
        sql.append(" ORDER BY ");
        sql.append(" "+ Mbj14MediaOutCtrl.OUTPUTFLG + " ASC, ");
        sql.append(" "+ Mbj14MediaOutCtrl.SORTNO + " ASC, ");
        sql.append(" " + Mbj03Media.SORTNO + " ASC ");

        return sql.toString();
    }
    /**
     * ���[�o�͔}�̂̌������s���܂�
     *
     * @return ���[�o�͔}��VO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<OutputMediaVO> findOutputMediaList(
            FindExcelOutSettingCondition cond) throws HAMException {

        super.setModel(new OutputMediaVO());

        try {
            _sqlMode = SqlMode.DEFAULT;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ���[�o�͔}�̂̌������s���܂�
     *
     * @return ���[�o�͔}��VO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<OutputMediaVO> findOutputReportMediaList(
            FindExcelOutSettingCondition cond,String searchMedia) throws HAMException {

        super.setModel(new OutputMediaVO());

        try {
            _sqlMode = SqlMode.REPORTOUT;
            _searchMedia = searchMedia;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
