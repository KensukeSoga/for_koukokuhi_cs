package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �c�ƍ�Ƒ䒠DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj02EigyoDaichoDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj02EigyoDaichoDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj02EigyoDaichoDAO createTbj02EigyoDaichoDAO() {
        return (Tbj02EigyoDaichoDAO) DaoFactory.createDao(Tbj02EigyoDaichoDAO.class);
    }

}
