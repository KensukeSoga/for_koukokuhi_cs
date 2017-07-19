package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �L�����y�[���ꗗ�X�VDAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/7 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class CampaignRegisterDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private CampaignRegisterDAOFactory() {
    }

    /**
     * �L�����y�[���f�[�^�X�VDAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static CampaignRegisterDAO createCampaignRegisterDAO() {
        return (CampaignRegisterDAO) DaoFactory.createDao(CampaignRegisterDAO.class);
    }

}
