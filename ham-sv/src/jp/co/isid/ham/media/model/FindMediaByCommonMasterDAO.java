package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

public class FindMediaByCommonMasterDAO extends AbstractRdbDao {

    /** �������� */
    private FindMediaByCommonMasterCondition _condition = null;

    /** SQL���[�h */
    private enum SqlMode{NAME,CODE };
    private SqlMode _sqlMode = SqlMode.NAME;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMediaByCommonMasterDAO() {
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
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return RepaVbjaMeu20MsMzBt.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu20MsMzBt.SZKBN
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAICD
                ,RepaVbjaMeu20MsMzBt.KBANCD
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK
                ,RepaVbjaMeu20MsMzBt.BTAISYAKCD
                ,RepaVbjaMeu20MsMzBt.BTAISYASEQNO
                ,RepaVbjaMeu20MsMzBt.KYUTRCD
                ,RepaVbjaMeu20MsMzBt.KHYOYMD
                ,RepaVbjaMeu20MsMzBt.JANR1
                ,RepaVbjaMeu20MsMzBt.JANR2
                ,RepaVbjaMeu20MsMzBt.JANR3
                ,RepaVbjaMeu20MsMzBt.CHUCHIKBN
                ,RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.NAME)) {
            sql=getMediaByMediaNm();
        }
        else if (_sqlMode.equals(SqlMode.CODE)) {
            sql=getMediaByMediaCd();
        }

        return sql;
    }

    /**
     * �L�[���[�h�������s��
     * @return SQL��
     */
    private String getMediaByMediaNm() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //�A�Ԃ��擾
        sql.append(" ROW_NUMBER() OVER (ORDER BY "+  RepaVbjaMeu20MsMzBt.SZKBN + "," +RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + "," +RepaVbjaMeu20MsMzBt.KBANCD+") AS ROWNO ,");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ + " LIKE('%" + _condition.getSearchNm() + "%')");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SZKBN + " ='" + _condition.getMediaFlg() + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " ASC, ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.KBANCD + " ASC ");

        return sql.toString();
    }

    /**
     * �}�̃R�[�h�������s��
     * @return SQL��
     */
    private String getMediaByMediaCd() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //�A�Ԃ��擾
        sql.append(" ROW_NUMBER() OVER (ORDER BY "+  RepaVbjaMeu20MsMzBt.SZKBN + "," +RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + "," +RepaVbjaMeu20MsMzBt.KBANCD+") AS ROWNO ,");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" (" + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " || " + RepaVbjaMeu20MsMzBt.KBANCD + ") IN(" + _condition.getMediaCd() +")");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SZKBN + " ='" + _condition.getMediaFlg() + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " ASC, ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.KBANCD + " ASC ");

        return sql.toString();
    }

    /**
     * �L�[���[�h�Ō������s��
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaByCommonMasterVO> FindMediaByMediaNm(FindMediaByCommonMasterCondition cond) throws HAMException {

        super.setModel(new FindMediaByCommonMasterVO());

        try {
            _condition = cond;
            _sqlMode = SqlMode.NAME;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �}�̃R�[�h�Ō������s��
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaByCommonMasterVO> FindMediaByMediaCd(FindMediaByCommonMasterCondition cond) throws HAMException {

        super.setModel(new FindMediaByCommonMasterVO());

        try {
            _condition = cond;
            _sqlMode = SqlMode.CODE;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindMediaByCommonMasterVO> �ϊ���̌�������
     */
    @Override
    protected List<FindMediaByCommonMasterVO> createFindedModelInstances(List hashList) {

        List<FindMediaByCommonMasterVO> list = new ArrayList<FindMediaByCommonMasterVO>();

        if (getModel() instanceof FindMediaByCommonMasterVO) {

            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                FindMediaByCommonMasterVO vo = new FindMediaByCommonMasterVO();
                vo.setROWNO((BigDecimal)result.get("ROWNO"));
                vo.setSZKBN((String)result.get(RepaVbjaMeu20MsMzBt.SZKBN.toUpperCase()));
                vo.setSINZATSUBTAICD((String)result.get(RepaVbjaMeu20MsMzBt.SINZATSUBTAICD.toUpperCase()));
                vo.setKBANCD((String)result.get(RepaVbjaMeu20MsMzBt.KBANCD.toUpperCase()));
                vo.setSINZATSUBTAINMJ((String)result.get(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ.toUpperCase()));
                vo.setSINZATSUBTAINMK((String)result.get(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK.toUpperCase()));
                vo.setBTAISYAKCD((String)result.get(RepaVbjaMeu20MsMzBt.BTAISYAKCD.toUpperCase()));
                vo.setBTAISYASEQNO((String)result.get(RepaVbjaMeu20MsMzBt.BTAISYASEQNO.toUpperCase()));
                vo.setKYUTRCD((String)result.get(RepaVbjaMeu20MsMzBt.KYUTRCD.toUpperCase()));
                vo.setKHYOYMD((String)result.get(RepaVbjaMeu20MsMzBt.KHYOYMD.toUpperCase()));
                vo.setJANR1((String)result.get(RepaVbjaMeu20MsMzBt.JANR1.toUpperCase()));
                vo.setJANR2((String)result.get(RepaVbjaMeu20MsMzBt.JANR2.toUpperCase()));
                vo.setJANR3((String)result.get(RepaVbjaMeu20MsMzBt.JANR3.toUpperCase()));
                vo.setCHUCHIKBN((String)result.get(RepaVbjaMeu20MsMzBt.CHUCHIKBN.toUpperCase()));
                vo.setSINBUNDAIGOCD((String)result.get(RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD.toUpperCase()));

                // �������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
