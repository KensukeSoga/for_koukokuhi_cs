package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu19NbJk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu1ANbNaiyo;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

public class FindDiscountFlgDAO extends AbstractRdbDao {

    /** �������� */
    private FindDiscountFlgCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindDiscountFlgDAO() {
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
        return RepaVbjaMeu1ANbNaiyo.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu1ANbNaiyo.HMOKCD
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5
                ,RepaVbjaMeu1ANbNaiyo.NBIKRITU
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {
        return getDiscountFlg();
    }

    /**
     * �l����������SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getDiscountFlg() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" '" + _cond.getDaichoNo() + "' AS DAICHONO ,");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu19NbJk.TBNAME + ", ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu19NbJk.THSKGYCD + " = " + RepaVbjaMeu1ANbNaiyo.THSKGYCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.SEQNO + " = " + RepaVbjaMeu1ANbNaiyo.SEQNO +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.TRTNTSEQNO + " = " + RepaVbjaMeu1ANbNaiyo.TRTNTSEQNO +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.THSKGYCD + " ='" + _cond.getThskgycd() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.SEQNO + " ='" + _cond.getSeqNo() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.TRTNTSEQNO + " ='" + _cond.getTrtntSeqNo() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.GYOMKBN + " ='" + _cond.getWorkFlg() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.BTAICD + " ='" + _cond.getMediaCd()+ _cond.getKbanCd() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.HMOKCD + " ='" + _cond.getItems() +"' ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu19NbJk.TYSYMD + ") <=" + _cond.getKikanFrom() +" ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu19NbJk.TYEYMD + ") >=" + _cond.getKikanTo() +" ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu1ANbNaiyo.TYSYMD + ") <=" + _cond.getKikanFrom() +" ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu1ANbNaiyo.TYEYMD + ") >=" + _cond.getKikanTo() +" ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.MSCHUOCHIHKBN + " =(");
        sql.append(" SELECT ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.CHUCHIKBN + " ");
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " ='" + _cond.getMediaCd() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.KBANCD + " ='" + _cond.getKbanCd() + "' ");
        sql.append(" ) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.GYOMKBN + " ='" + _cond.getWorkFlg() + "' ");

        return sql.toString();
    }

    /**
     * �l�����̌������s���܂�
     *
     * @return �L�����y�[���ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindDiscountFlgVO> findDiscountFlg(FindDiscountFlgCondition cond) throws HAMException {

        super.setModel(new FindDiscountFlgVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindAuthorityAccountBookVO> �ϊ���̌�������
     */
    @Override
    protected List<FindDiscountFlgVO> createFindedModelInstances(List hashList) {

        List<FindDiscountFlgVO> list = new ArrayList<FindDiscountFlgVO>();

        if (getModel() instanceof FindDiscountFlgVO) {
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                FindDiscountFlgVO vo = new FindDiscountFlgVO();
                vo.setDAICHONO((String)result.get("DAICHONO"));
                vo.setHMOKCD((String)result.get(RepaVbjaMeu1ANbNaiyo.HMOKCD.toUpperCase()));
                vo.setNBIKNIYOKBN1((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1.toUpperCase()));
                vo.setNBIKNIYOKBN2((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2.toUpperCase()));
                vo.setNBIKNIYOKBN3((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3.toUpperCase()));
                vo.setNBIKNIYOKBN4((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4.toUpperCase()));
                vo.setNBIKNIYOKBN5((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5.toUpperCase()));
                vo.setNBIKRITU((BigDecimal)result.get(RepaVbjaMeu1ANbNaiyo.NBIKRITU.toUpperCase()));

                // �������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
