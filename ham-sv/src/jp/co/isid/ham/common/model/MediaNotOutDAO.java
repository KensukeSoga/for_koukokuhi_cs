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
 * ���[�ɏo�͂��Ȃ��}�̎擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class MediaNotOutDAO extends AbstractSimpleRdbDao{


    /** �������� */
    private FindExcelOutSettingCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public MediaNotOutDAO() {
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
                Mbj03Media.MEDIACD
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Mbj03Media.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj03Media.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Mbj03Media.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj03Media.MEDIACD
                ,Mbj03Media.MEDIANM
                ,Mbj03Media.HCMEDIANM
                ,Mbj03Media.DNEBIKI
                ,Mbj03Media.SORTNO
                ,Mbj03Media.UPDDATE
                ,Mbj03Media.UPDNM
                ,Mbj03Media.UPDAPL
                ,Mbj03Media.UPDID
        };
    }


    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getNotOutMediaList();
    }


    /**
     * ���[�ɏo�͂��Ȃ��}�̂��������܂�
     *
     * @return String SQL��
     */
    private String getNotOutMediaList() {
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
        sql.append(" "+ Mbj03Media.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" NOT EXISTS(SELECT ");
        sql.append(" " + Mbj14MediaOutCtrl.MEDIACD + " ");
        sql.append(" FROM ");
        sql.append(" "+ Mbj14MediaOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj03Media.MEDIACD + "=" + Mbj14MediaOutCtrl.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj14MediaOutCtrl.REPORTCD + " = '" + _cond.getReportcd() + "' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj14MediaOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj14MediaOutCtrl.OUTPUTFLG + " = 1 ");
        sql.append(" ) ");
        sql.append(" ORDER BY ");
        sql.append(" " + Mbj03Media.SORTNO + " ASC ");
        sql.append("," + Mbj03Media.MEDIACD + " ASC ");

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
    public List<Mbj03MediaVO> findNotOutMediaList(
            FindExcelOutSettingCondition cond) throws HAMException {

        super.setModel(new Mbj03MediaVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
