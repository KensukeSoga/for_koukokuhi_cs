package jp.co.isid.ham.common.model;

import jp.co.isid.ham.media.model.FindCampaignDetailsDAO;
import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �L�����y�[������DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj13CampDetailDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj13CampDetailDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj13CampDetailDAO createTbj13CampDetailDAO() {
        return (Tbj13CampDetailDAO) DaoFactory.createDao(Tbj13CampDetailDAO.class);
    }

    public static FindCampaignDetailsDAO createFindCampaignDetailsDAO() {
    	return (FindCampaignDetailsDAO)DaoFactory.createDao(FindCampaignDetailsDAO.class);
    }

}
