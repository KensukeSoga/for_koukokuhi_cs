package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�ύX���ODAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj23LogEigyoDaichoDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj23LogEigyoDaichoDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj23LogEigyoDaichoDAO createTbj23LogEigyoDaichoDAO() {
        return (Tbj23LogEigyoDaichoDAO) DaoFactory.createDao(Tbj23LogEigyoDaichoDAO.class);
    }

}
