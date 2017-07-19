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
 * ���[�ɏo�͂��Ȃ��Ԏ�擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class CarNotOutDAO extends AbstractSimpleRdbDao{

    /** �������� */
    private FindExcelOutSettingCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public CarNotOutDAO() {
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
                Mbj05Car.DCARCD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj05Car.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj05Car.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj05Car.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj05Car.DCARCD
                ,Mbj05Car.KEIRETSUCD
                ,Mbj05Car.CARNM
                ,Mbj05Car.DISPSTS
                ,Mbj05Car.SORTNO
                ,Mbj05Car.UPDDATE
                ,Mbj05Car.UPDNM
                ,Mbj05Car.UPDAPL
                ,Mbj05Car.UPDID
        };
    }


    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getNotOutCarList();
    }


    /**
     * ���[�ɏo�͂��Ȃ��}�̂��������܂�
     *
     * @return String SQL��
     */
    private String getNotOutCarList() {
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
        sql.append(" "+ Mbj05Car.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj05Car.DISPSTS + " = '1' ");
        sql.append(" AND ");
        sql.append(" NOT EXISTS(SELECT ");
        sql.append(" " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" FROM ");
        sql.append(" "+ Mbj13CarOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj05Car.DCARCD + " = " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" ) ");
        sql.append(" ORDER BY ");
        sql.append(" " + Mbj05Car.SORTNO + " ASC ");
        sql.append("," + Mbj05Car.KEIRETSUCD + " ASC ");
        sql.append("," + Mbj05Car.DCARCD + " ASC ");

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
    public List<Mbj05CarVO> findNotOutCarList(
            FindExcelOutSettingCondition cond) throws HAMException {

        super.setModel(new Mbj05CarVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
