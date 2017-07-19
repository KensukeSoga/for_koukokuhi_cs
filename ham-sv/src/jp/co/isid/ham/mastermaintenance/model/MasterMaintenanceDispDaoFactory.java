package jp.co.isid.ham.mastermaintenance.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �}�X�^�����e�i���X�\���pDAOFaotory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/04 �X)<BR>
 * </P>
 * @author �X
 */
public class MasterMaintenanceDispDaoFactory extends DaoFactory
{
    /**
    * �C���X�^���X�����֎~���܂�
    */
    private MasterMaintenanceDispDaoFactory()
    {
    }

    /**
    * DAO�C���X�^���X�𐶐����܂�
    * @return DAO�C���X�^���X
    */
    public static MasterMaintenanceDispDao createMasterMaintenanceDispDao()
    {
        return (MasterMaintenanceDispDao) DaoFactory.createDao(MasterMaintenanceDispDao.class);
    }

}
