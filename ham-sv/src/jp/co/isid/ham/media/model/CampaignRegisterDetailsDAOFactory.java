package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �L�����y�[���ڍ׃f�[�^�X�VDAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/14 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class CampaignRegisterDetailsDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private CampaignRegisterDetailsDAOFactory() {
    }

    /**
     * �L�����y�[���f�[�^�X�VDAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static CampaignRegisterDetailsDAO createCampaignRegisterDetailsDAO() {
        return (CampaignRegisterDetailsDAO) DaoFactory.createDao(CampaignRegisterDetailsDAO.class);
    }

}
