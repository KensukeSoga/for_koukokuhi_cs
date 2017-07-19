package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���W�I��AllocationPictureb�ԑg�l�b�g�Ǐ�񌟍�DAO�t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/12/10 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureProgramStationDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindRdAllocationPictureProgramStationDAOFactory() {
    }

    /**
     * ���W�I��AllocationPicture�ԑg�l�b�g�Ǐ�񌟍�DAO�C���X�^���X�𐶐����܂�
     * @return ���W�I��AllocationPicture�ԑg�l�b�g�Ǐ�񌟍�DAO�C���X�^���X
     */
    public static FindRdAllocationPictureProgramStationDAO createFindRdAllocationProgramStationDAOFactory() {
        return (FindRdAllocationPictureProgramStationDAO) DaoFactory.createDao(FindRdAllocationPictureProgramStationDAO.class);
    }

}
