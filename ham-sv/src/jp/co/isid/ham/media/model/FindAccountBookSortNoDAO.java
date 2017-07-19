package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

public class FindAccountBookSortNoDAO extends AbstractRdbDao {

    FindAccountBookSortNoCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindAccountBookSortNoDAO() {
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
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }


    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append("NVL(MAX(");
        sql.append(Tbj02EigyoDaicho.SORTNO);
        sql.append("), 0) + 1 AS SORTNO");

        sql.append(" FROM ");

        sql.append("(");
        sql.append("SELECT ");
        sql.append(Tbj01MediaPlan.PHASE);
        sql.append(" AS MYPHASE");
        sql.append(" FROM ");
        sql.append(Tbj01MediaPlan.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj01MediaPlan.MEDIAPLANNO);
        sql.append(" = ");
        sql.append(_cond.getMEDIAPLANNO());
        sql.append(") X");

        sql.append(", ");
        sql.append(Tbj01MediaPlan.TBNAME);

        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.TBNAME);

        sql.append(" WHERE ");
        sql.append(Tbj01MediaPlan.PHASE);
        sql.append(" = ");
        sql.append(" MYPHASE");
        sql.append(" AND ");
        sql.append(Tbj01MediaPlan.MEDIAPLANNO);
        sql.append(" = ");
        sql.append(Tbj02EigyoDaicho.MEDIAPLANNO);


        return sql.toString();
    }

    /**
     * �\�[�g�����擾����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindAccountBookSortNoVO> selectVO(FindAccountBookSortNoCondition cond) throws HAMException {

        super.setModel(new FindAccountBookSortNoVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
