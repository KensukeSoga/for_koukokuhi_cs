package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 契約情報登録画面Updateの結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/18 新HAMチーム)<BR>
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateContractInfoResult extends AbstractServiceResult{
//
//    /* =============================================================================================*/
//    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
//    private String _dummy;
//
//    /**
//     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
//     * @return String ダミープロパティ
//     */
//    public String getDummy() {
//        return _dummy;
//    }
//
//    /**
//     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
//     * @param dummy ダミープロパティ
//     */
//    public void setDummy(String dummy) {
//        this._dummy = dummy;
//    }
//    /* =============================================================================================*/
//    /** 契約情報テーブルVOリスト */
//    private List<Tbj16ContractInfoVO> _contractInfoVOList = null;
//
//    /** JASRACテーブルVOリスト */
//    private List<Tbj19JasracVO> _jasracVOList = null;
//
//    /** コンテンツテーブル、素材登録テーブルVOリスト */
//    private List<ContentMaterialVO> _contentMaterialVOList = null;
//
//    /** 素材登録10桁CMコードに紐づく契約情報を取得VOリスト */
//    private List<ContractContentVO> _contractContentVOList = null;
//
//    /**
//     * 契約情報テーブルVOリストを取得する
//     * @return 契約情報テーブルVOリスト
//     */
//    public List<Tbj16ContractInfoVO> getTbj16ContractInfoVOList() {
//        return _contractInfoVOList;
//    }
//
//    /**
//     * 契約情報テーブルVOリストを設定する
//     * @param contractInfoVOList コードマスタVOリスト
//     */
//    public void setTbj16ContractInfoVOList(List<Tbj16ContractInfoVO> contractInfoVOList) {
//        this._contractInfoVOList = contractInfoVOList;
//    }
//
//    /**
//     * JASRACテーブルを取得する
//     * @return JASRACテーブルVOリスト
//     */
//    public List<Tbj19JasracVO> getTbj19JasracVO() {
//        return _jasracVOList;
//    }
//
//    /**
//     * JASRACテーブルを設定する
//     * @param jasracVOList コードマスタVOリスト
//     */
//    public void setTbj19JasracVO(List<Tbj19JasracVO> jasracVOList) {
//        this._jasracVOList = jasracVOList;
//    }
//
//    /**
//     * コンテンツテーブル、素材登録テーブルを取得する
//     * @return コンテンツテーブル、素材登録テーブルVOリスト
//     */
//    public List<ContentMaterialVO> getContentMaterialVO() {
//        return _contentMaterialVOList;
//    }
//
//    /**
//     * コンテンツテーブル、素材登録テーブルを設定する
//     * @param contentMaterialVOList コンテンツテーブル、素材登録テーブルVOリスト
//     */
//    public void setContentMaterialVO(List<ContentMaterialVO> contentMaterialVOList) {
//        this._contentMaterialVOList = contentMaterialVOList;
//    }
//
//    /**
//     * 素材登録10桁CMコードに紐づく契約情報を取得する
//     * @return 素材登録10桁CMコードに紐づく契約情報VOリスト
//     */
//    public List<ContractContentVO> getContractContentVO() {
//        return _contractContentVOList;
//    }
//
//    /**
//     * 素材登録10桁CMコードに紐づく契約情報を設定する
//     * @param contentMaterialVOList 素材登録10桁CMコードに紐づく契約情報VOリスト
//     */
//    public void setContractContentVO(List<ContractContentVO> contractContentVOList) {
//        this._contractContentVOList = contractContentVOList;
//    }

}
