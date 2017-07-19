package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �Ԏ�o�͐ݒ�}�X�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class OutputCarDAO extends AbstractSimpleRdbDao{

    /** �������� */
    private FindExcelOutSettingCondition _cond = null;
    private String _searchCar;

    private enum SqlMode{DEFAULT,REPORTOUT};
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public OutputCarDAO() {
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
        return Mbj13CarOutCtrl.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj13CarOutCtrl.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.REPORTCD
                ,Mbj13CarOutCtrl.DCARCD
                ,Mbj05Car.CARNM
                ,Mbj13CarOutCtrl.OUTPUTFLG
                ,Mbj13CarOutCtrl.SORTNO
                ,Mbj05Car.SORTNO
                ,Mbj13CarOutCtrl.PHASE
                ,Mbj13CarOutCtrl.UPDDATE
                ,Mbj13CarOutCtrl.UPDNM
                ,Mbj13CarOutCtrl.UPDAPL
                ,Mbj13CarOutCtrl.UPDID
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
            return getOutputCarList();
        } else if (_sqlMode.equals(SqlMode.REPORTOUT)) {
            return getOutputReportCarList();
        } else {
            return null;
        }
    }


    /**
     * �Ԏ큕������SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getOutputCarList() {
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
        sql.append(" "+ Mbj13CarOutCtrl.TBNAME + ", ");
        sql.append(" "+ Mbj05Car.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj05Car.DISPSTS + " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.DCARCD+ " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" ORDER BY ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " ASC, ");
        sql.append(" "+ Mbj13CarOutCtrl.SORTNO + " ASC, ");
        sql.append(" " + Mbj05Car.SORTNO + " ASC ");

        return sql.toString();
    }

    /**
     * �Ԏ큕������SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getOutputReportCarList() {
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
        sql.append(" "+ Mbj13CarOutCtrl.TBNAME + ", ");
        sql.append(" "+ Mbj05Car.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj05Car.DISPSTS + " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.DCARCD+ " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.DCARCD + " IN(" + _searchCar + ")");
        sql.append(" ORDER BY ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " ASC, ");
        sql.append(" "+ Mbj13CarOutCtrl.SORTNO + " ASC, ");
        sql.append(" " + Mbj05Car.SORTNO + " ASC ");

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
    public List<OutputCarVO> findOutputCarList(
            FindExcelOutSettingCondition cond) throws HAMException {

        super.setModel(new OutputCarVO());

        try {
            _cond = cond;
            _sqlMode = SqlMode.DEFAULT;
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
    public List<OutputCarVO> findOutputReportCarList(
            FindExcelOutSettingCondition cond,String searchCar) throws HAMException {

        super.setModel(new OutputCarVO());

        try {
            _cond = cond;
            _sqlMode = SqlMode.REPORTOUT;
            _searchCar = searchCar;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
