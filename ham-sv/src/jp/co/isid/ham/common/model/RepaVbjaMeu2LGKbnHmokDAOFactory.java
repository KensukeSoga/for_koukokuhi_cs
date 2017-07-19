package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �Ɩ��敪��ڑΉ��}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu2LGKbnHmokDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMeu2LGKbnHmokDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMeu2LGKbnHmokDAO createRepaVbjaMeu2LGKbnHmokDAO() {
        return (RepaVbjaMeu2LGKbnHmokDAO) DaoFactory.createDao(RepaVbjaMeu2LGKbnHmokDAO.class);
    }

}
