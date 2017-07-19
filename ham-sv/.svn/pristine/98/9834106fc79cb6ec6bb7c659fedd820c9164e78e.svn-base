package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * 営業作業台帳履歴DAOのファクトリクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class FindAccountBookLogDAOFactory extends DaoFactory{
    /**
    * インスタンス化を禁止します
    */
   private FindAccountBookLogDAOFactory() {
   }

   /**
    * 営業作業台帳履歴取得DAOインスタンスを生成
    *
    * @return DAOインスタンス
    */
   public static FindAccountBookLogDAO createFindAccountBookLogDAO() {
       return (FindAccountBookLogDAO) DaoFactory.createDao(FindAccountBookLogDAO.class);
   }
}
