package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class FindSpaceDAO extends AbstractSimpleRdbDao {

    /** �f�[�^�������� */
    private FindAuthorityAccountBookCondition _cond;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindSpaceDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        // new String[] {};
        return null;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj02EigyoDaicho.SPACE
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getMediaCategory();
    }


    /**
     *�}�̎�ʎ擾��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getMediaCategory() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" "+ Tbj02EigyoDaicho.TBNAME + ", ");
        sql.append(" "+ Mbj03Media.TBNAME + ", ");
        sql.append(" "+ Mbj10MediaSec.TBNAME + ", ");
        sql.append(" "+ Mbj05Car.TBNAME + ", ");
        sql.append(" "+ Mbj11CarSec.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj03Media.MEDIACD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " + Mbj05Car.DCARCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj03Media.MEDIACD + " = " + Mbj10MediaSec.MEDIACD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Mbj05Car.DCARCD + " = " + Mbj11CarSec.DCARCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = 'M01'");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.SPACE + " IS NOT NULL ");
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.SECTYPE + " = 0 ");
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.AUTHORITY + " > 0 ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.AUTHORITY + " > 0 ");
        sql.append(" ORDER BY ");
        sql.append(" "+ Mbj03Media.SORTNO + " ASC ");

        return sql.toString();
    }

    /**
     * �}�̎�ʂ̌������s���܂�
     *
     * @return �Ԏ�ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindSpaceVO> findSpace(FindAuthorityAccountBookCondition cond) throws HAMException {

        super.setModel(new FindSpaceVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}