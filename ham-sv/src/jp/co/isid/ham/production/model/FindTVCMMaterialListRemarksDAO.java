package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.T_Remarks;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* TVCM�f�ވꗗ���L��������DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �EHDX�Ή�(2016/03/09 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/
public class FindTVCMMaterialListRemarksDAO extends AbstractSimpleRdbDao{

    /** �������� */
    private FindTVCMMaterialListCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindTVCMMaterialListRemarksDAO() {
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

        return getRemarks();
    }

    /**
     * TVCM�f�ވꗗ���L��������SQL����Ԃ��܂�
     * @return String SQL��
     */
    private String getRemarks()
    {
        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" RM." + T_Remarks.INSERTDATE + ",");
        sql.append(" RM." + T_Remarks.INSERTUSERID + ",");
        sql.append(" RM." + T_Remarks.UPDATEDATE + ",");
        sql.append(" RM." + T_Remarks.UPDATEUSERID + ",");
        sql.append(" RM." + T_Remarks.DELETEFLG + ",");
        sql.append(" RM." + T_Remarks.SYSTEMID + ",");
        sql.append(" RM." + T_Remarks.CLIENTSBT + ",");
        sql.append(" RM." + T_Remarks.REMARKSID + ",");
        sql.append(" RM." + T_Remarks.YEAR + ",");
        sql.append(" RM." + T_Remarks.MONTH + ",");
        sql.append(" RM." + T_Remarks.BRANDID + ",");
        sql.append(" RM." + T_Remarks.MESSAGE + ",");
        sql.append(" UUSR." + T_UserInfo.USERNAME + ",");
        sql.append(" UGRP." + T_SecurityGroup.SECURITYGROUPNAME);

        sql.append(" FROM");
        sql.append(" " + T_Remarks.TBNAME + " RM");
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + T_UserInfo.TBNAME + " UUSR ON UUSR." + T_UserInfo.USERID + " = RM." + T_Remarks.UPDATEUSERID + " AND");
        sql.append(" UUSR." + T_UserInfo.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "'");
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + T_SecurityGroup.TBNAME + " UGRP ON UGRP." + T_SecurityGroup.SECURITYGROUPCODE + " = UUSR." + T_UserInfo.SECURITYGROUPCODE + " AND");
        sql.append(" UGRP." + T_SecurityGroup.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "'");

        sql.append(" WHERE");
        sql.append(" RM." + T_Remarks.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" RM." + T_Remarks.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" RM." + T_Remarks.YEAR + " = '" + _cond.getYearMonth().substring(0, 4) + "' AND");
        sql.append(" RM." + T_Remarks.MONTH + " = '" + _cond.getYearMonth().substring(4, 6) + "'");

        sql.append(" ORDER BY");
        sql.append(" RM." + T_Remarks.UPDATEDATE + " DESC");

        return sql.toString();
    }

    /**
     * TVCM�f�ވꗗ���L��������
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindTVCMMaterialListRemarksVO> findTVCMMaterialListRemarks(FindTVCMMaterialListCondition cond) throws HAMException {

        super.setModel(new FindTVCMMaterialListRemarksVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
