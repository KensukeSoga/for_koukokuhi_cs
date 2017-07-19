package jp.co.isid.ham.production.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
* <P>
* 素材一覧(共有OA期間)最大年月取得DAOファクトリクラス
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/04/06 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/

public class GetMaterialListCmnMaxSozaiYmDAOFactory extends DaoFactory{

    /**
     * インスタンス化を禁止します
     */
    private GetMaterialListCmnMaxSozaiYmDAOFactory() {
    }

    /**
     * 素材一覧(共有OA期間)最大年月取得DAOインスタンスを生成します
     * @return 素材一覧(共有OA期間)最大年月取得DAO
     */
    public static GetMaterialListCmnMaxSozaiYmDAO createGetMaterialListCmnMaxSozaiYmDAO() {
        return (GetMaterialListCmnMaxSozaiYmDAO) DaoFactory.createDao(GetMaterialListCmnMaxSozaiYmDAO.class);
    }
}
