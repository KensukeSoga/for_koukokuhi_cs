package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �c�ƍ�Ƒ䒠����DAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class FindAccountBookLogDAOFactory extends DaoFactory{
    /**
    * �C���X�^���X�����֎~���܂�
    */
   private FindAccountBookLogDAOFactory() {
   }

   /**
    * �c�ƍ�Ƒ䒠�����擾DAO�C���X�^���X�𐶐�
    *
    * @return DAO�C���X�^���X
    */
   public static FindAccountBookLogDAO createFindAccountBookLogDAO() {
       return (FindAccountBookLogDAO) DaoFactory.createDao(FindAccountBookLogDAO.class);
   }
}
