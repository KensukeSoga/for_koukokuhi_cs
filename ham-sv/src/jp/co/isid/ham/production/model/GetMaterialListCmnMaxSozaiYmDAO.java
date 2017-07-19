package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOACondition;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOAVO;
import jp.co.isid.ham.integ.tbl.Tbj43SozaiKanriListCmnOA;
import jp.co.isid.ham.integ.tbl.Tbj45LogSozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* �f�ވꗗ(���LOA����)�ő�N���擾DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2016/04/06 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/

public class GetMaterialListCmnMaxSozaiYmDAO extends AbstractSimpleRdbDao{

    /** �������� */
    private Tbj43SozaiKanriListCmnOACondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public GetMaterialListCmnMaxSozaiYmDAO() {
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
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{ };
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
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return findMaxSozaiYm();
    }

    /**
     * �ő�N���擾SQL����Ԃ��܂�
     * @return String SQL��
     */
    private String findMaxSozaiYm()
    {
        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" MAX(SOZAIYM)" + Tbj43SozaiKanriListCmnOA.SOZAIYM);

        sql.append(" FROM");
        sql.append(" (SELECT");
        sql.append(" MAX(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ") + 1 / 86400 " + " SOZAIYM");

        sql.append(" FROM");
        sql.append(" "+ Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + _cond.getDcarcd() + "' AND");
        sql.append(" TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_cond.getSozaiym()) + "' AND");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECKBN + " = '" + _cond.getReckbn() + "'");

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" MAX(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ") + 1 / 86400 ");

        sql.append(" FROM");
        sql.append(" "+ Tbj45LogSozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.DCARCD + " = '" + _cond.getDcarcd() + "' AND");
        sql.append(" TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_cond.getSozaiym()) + "' AND");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.RECKBN + " = '" + _cond.getReckbn() + "')");

        return sql.toString();
    }

    /**
     * �f�ވꗗ(���LOA����)�ő�N���擾
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> findMaxSozaiYm(Tbj43SozaiKanriListCmnOACondition cond) throws HAMException {

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
