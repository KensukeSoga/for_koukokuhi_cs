package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���W�I��AllocationPicture�f�ޏ�񌟍�DAO�t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureMaterialDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindRdAllocationPictureMaterialDAOFactory() {
    }

    /**
     * ���W�I��AllocationPicture��񌟍�DAO�C���X�^���X�𐶐����܂�
     * @return ���W�I��AllocationPicture��񌟍�DAO�C���X�^���X
     */
    public static FindRdAllocationPictureMaterialDAO createFindRdAllocationMaterialDAOFactory() {
        return (FindRdAllocationPictureMaterialDAO) DaoFactory.createDao(FindRdAllocationPictureMaterialDAO.class);
    }

}
