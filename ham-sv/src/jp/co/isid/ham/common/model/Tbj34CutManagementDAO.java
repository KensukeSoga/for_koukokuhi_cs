package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj34CutManagement;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �팸�z�Ǘ�DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj34CutManagementDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj34CutManagementCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj34CutManagementDAO() {
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
                Tbj34CutManagement.CLASSCD
                ,Tbj34CutManagement.DATEFROM
                ,Tbj34CutManagement.DATETO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj34CutManagement.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj34CutManagement.CRTDATE
                ,Tbj34CutManagement.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj34CutManagement.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj34CutManagement.CLASSCD
                ,Tbj34CutManagement.DATEFROM
                ,Tbj34CutManagement.DATETO
                ,Tbj34CutManagement.CUTMONEY
                ,Tbj34CutManagement.CRTDATE
                ,Tbj34CutManagement.CRTNM
                ,Tbj34CutManagement.CRTAPL
                ,Tbj34CutManagement.CRTID
                ,Tbj34CutManagement.UPDDATE
                ,Tbj34CutManagement.UPDNM
                ,Tbj34CutManagement.UPDAPL
                ,Tbj34CutManagement.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        return getKikan();
    }

    /**
     * ����SQL���擾���܂�
     * @return
     */
    private String getKikan() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(",");
            }
        }

        sql.append(" FROM ");
        sql.append(" " + getTableName());
        sql.append(" WHERE ");
        sql.append(" TO_DATE(" + Tbj34CutManagement.DATEFROM + ") >= TO_DATE('" + _condition.getDatefrom() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" TO_DATE(" + Tbj34CutManagement.DATETO + ") <= TO_DATE('" + _condition.getDateto() + "','YYYY/MM') ");

        return sql.toString();
    }


    /**
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj34CutManagementVO> selectVO(Tbj34CutManagementCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj34CutManagementVO());
        _condition = condition;
        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
