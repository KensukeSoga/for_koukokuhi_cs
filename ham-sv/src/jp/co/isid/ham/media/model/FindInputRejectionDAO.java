package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 *
 * <P>
 * �L�����y�[���ڍד��͋��ۃf�[�^�̏��擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/18 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindInputRejectionDAO extends AbstractRdbDao {


    /** �f�[�^�������� */
    private String _campCd;

    private final String BAITAICNT = "BAITAI_CNT";
    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindInputRejectionDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }


    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        // new String[] {};
        return null;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj01MediaPlan.TBNAME;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {
        return getInputRejectionDataByMediaPlan();
    }

    /**
     *�L�����y�[���ڍד��͋��ۃf�[�^.
     *
     * @return String SQL��
     */
    private String getInputRejectionDataByMediaPlan()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ", ");
        sql.append(" TO_CHAR(" + Tbj01MediaPlan.YOTEIYM+ ",'YYYY/MM') AS " + Tbj01MediaPlan.YOTEIYM + " ");
        sql.append(" FROM ");
        sql.append( " " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj01MediaPlan.CAMPCD + " ='" + _campCd + "' ");
        sql.append(" GROUP BY ");
        sql.append(" TO_CHAR(" + Tbj01MediaPlan.YOTEIYM+ ",'YYYY/MM')" + ", ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " ");
        sql.append(" HAVING ");
        sql.append(" COUNT(" + Tbj01MediaPlan.MEDIACD + ") > 1");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ", ");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + " ");

        return sql.toString();
    }


    /**
     * �}�̏󋵊Ǘ��̓��͋��ۃf�[�^�������s���܂�
     *
     * @return �}�̏󋵊Ǘ����͋��ۃf�[�^�ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindInputRejectionVO> findMediaPlanInputRejection(
            String campCd) throws HAMException {

        super.setModel(new FindInputRejectionVO());

        try {
            _campCd = campCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindJissiNoCntCondVO> �ϊ���̌�������
     */
    @Override
    protected List<FindInputRejectionVO> createFindedModelInstances(List hashList) {

        List<FindInputRejectionVO> list = new ArrayList<FindInputRejectionVO>();

        if (getModel() instanceof FindInputRejectionVO) {

            for (int i = 0; i < hashList.size(); i++) {

                Map result = (Map) hashList.get(i);
                FindInputRejectionVO vo = new FindInputRejectionVO();

                vo.setMEDIACD((String)result.get(Tbj01MediaPlan.MEDIACD.toUpperCase()));
                vo.setYOTEIYM((String)result.get(Tbj01MediaPlan.YOTEIYM.toUpperCase()));
                vo.setBAITAICNT((String)result.get(this.BAITAICNT.toUpperCase()));
                // �������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }
        return list;
    }

}