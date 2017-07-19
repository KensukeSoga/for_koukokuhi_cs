package jp.co.isid.ham.mastermaintenance.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �}�X�^�����e�i���X�`�F�b�N�pDAOFaotory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 �X)<BR>
 * </P>
 * @author �X
 */
public class MasterMaintenanceCheckDaoFactory extends DaoFactory
{
    /**
    * �C���X�^���X�����֎~���܂�
    */
    private MasterMaintenanceCheckDaoFactory()
    {
    }

    /**
    * DAO�C���X�^���X�𐶐����܂�
    * @return DAO�C���X�^���X
    */
    public static MasterMaintenanceCheckDao createMasterMaintenanceCheckDao()
    {
        return (MasterMaintenanceCheckDao) DaoFactory.createDao(MasterMaintenanceCheckDao.class);
    }

}
