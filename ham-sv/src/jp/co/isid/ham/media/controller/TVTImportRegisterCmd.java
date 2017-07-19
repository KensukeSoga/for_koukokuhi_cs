package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.TVTImportRegisterManager;
import jp.co.isid.ham.media.model.TVTImportRegisterResult;
import jp.co.isid.ham.media.model.TVTImportRegisterVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * TVT取込み結果登録コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/22 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class TVTImportRegisterCmd extends Command{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

   /** 検索結果キー */
   private static final String RESULT_KEY = "RESULT_KEY";

   /** 検索条件 */
   private TVTImportRegisterVO _vo;

   /**
    * 検索条件を使用し、 キャンペーン一覧データ検索処理を実行します
    *
    * @throws HAMException
    *             検索に失敗した場合
    */
   @Override
   public void execute() throws HAMException {
       TVTImportRegisterManager manager = TVTImportRegisterManager.getInstance();
       manager.TVTImport(_vo);
       getResult().set(RESULT_KEY, new TVTImportRegisterResult());
   }

   /**
    * 検索条件を設定します
    *
    * @param condition
    *            CampaignList 検索条件
    */
   public void setTVTImportRegisterCondition(TVTImportRegisterVO vo) {
       _vo = vo;
   }

   /**
    * キャンペーン一覧検索結果を返します
    *
    * @return FindCampaignListResult 条件検索結果
    */
   public TVTImportRegisterResult getTVTImportRegisterResult() {
       return (TVTImportRegisterResult) super.getResult().get(RESULT_KEY);
   }

}
