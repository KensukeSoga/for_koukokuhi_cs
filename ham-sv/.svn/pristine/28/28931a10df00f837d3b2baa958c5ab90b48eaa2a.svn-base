package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 契約情報取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/20 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetContractInfoListResult extends AbstractServiceResult {

    /* =============================================================================================*/
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** 契約情報テーブルVOリスト */
    private List<Tbj16ContractInfoVO> _tbj16ContractInfoVOList = null;

    /** 使用素材表示用(タレント・ナレーター)データVOリスト */
    private List<FindUseMaterialVO> _findUseMaterialTalentVOList = null;

    /** 使用素材表示用データ(楽曲)VOリスト */
    private List<FindUseMaterialVO> _findUseMaterialMusicVOList = null;

    /**
     * 契約情報テーブルVOリストを取得する
     * @return 契約情報テーブルVOリスト
     */
    public List<Tbj16ContractInfoVO> getTbj16ContractInfoVOList() {
        return _tbj16ContractInfoVOList;
    }

    /**
     * 契約情報テーブルVOリストを設定する
     * @param tbj16ContractInfoVOList 契約情報テーブルVOリスト
     */
    public void setTbj16ContractInfoVOList(List<Tbj16ContractInfoVO> tbj16ContractInfoVOList) {
        this._tbj16ContractInfoVOList = tbj16ContractInfoVOList;
    }

    /**
     * 使用素材表示用(タレント・ナレーター)データを取得する
     * @return 使用素材表示用データVOリスト
     */
    public List<FindUseMaterialVO> getFindUseMaterialTalentVOList() {
        return _findUseMaterialTalentVOList;
    }

    /**
     * 使用素材表示用(タレント・ナレーター)データを設定する
     * @param findUseMaterialVOList 使用素材表示用データVOリスト
     */
    public void setFindUseMaterialTalentVOList(List<FindUseMaterialVO> findUseMaterialTalentVOList) {
        this._findUseMaterialTalentVOList = findUseMaterialTalentVOList;
    }

    /**
     * 使用素材表示用(楽曲)データを取得する
     * @return 使用素材表示用データVOリスト
     */
    public List<FindUseMaterialVO> getFindUseMaterialMusicVOList() {
        return _findUseMaterialMusicVOList;
    }

    /**
     * 使用素材表示用(楽曲)データを設定する
     * @param findUseMaterialVOList 使用素材表示用データVOリスト
     */
    public void setFindUseMaterialMusicVOList(List<FindUseMaterialVO> findUseMaterialMusicVOList) {
        this._findUseMaterialMusicVOList = findUseMaterialMusicVOList;
    }
}

