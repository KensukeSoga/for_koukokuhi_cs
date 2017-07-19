package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �r���`�F�b�N�pDAOFaotory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/07 �X)<BR>
 * </P>
 * @author �X
 */
public class RegistExclusionDaoFactory extends DaoFactory
{
    /**
    * �C���X�^���X�����֎~���܂�
    */
    private RegistExclusionDaoFactory()
    {
    }

    /**
    * DAO�C���X�^���X�𐶐����܂�
    * @return DAO�C���X�^���X
    */
    public static RegistExclusionDao createRegistExclusionDao()
    {
        return (RegistExclusionDao) DaoFactory.createDao(RegistExclusionDao.class);
    }

}
