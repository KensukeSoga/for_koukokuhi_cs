package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj06HcBumonVO;
import jp.co.isid.ham.common.model.Mbj07HcUserVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.MediaListVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj03MediaMngVO;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HC媒体費作成検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCMediaCreationResult extends AbstractServiceResult {

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /** コードマスタ */
    private List<Mbj12CodeVO> _code;

    /** 部門マスタ */
    private List<Mbj06HcBumonVO> _bumon;

    /** カレンダーマスタ */
    private List<Mbj21CalendarVO> _calendar;

    /** HCユーザマスタ */
    private List<Mbj07HcUserVO> _user;

    /** 媒体費管理 */
    private List<Tbj03MediaMngVO> _mediaMng;

    /** 媒体・商品紐付けマスタ */
    private List<FindMediaProductVO> _mediaProduct;

    /** 媒体費見積明細管理 */
    private List<Tbj04MediaMngEstimateDetailVO> _estDtl;

    /** H新モデルコスト合計 */
    private List<FindSumHmCostVO> _sumHmCost;

    /** 車種 */
    private List<CarListVO> _car;

    /** 媒体 */
    private List<MediaListVO> _media;

    /** 見積案件/見積明細 */
    private List<FindEstItemDtlVO> _estItemDtl;

    /** HC商品マスタ */
    private List<FindHCProductVO> _product;

    /** 全社コードマスタ */
    private List<RepaVbjaMeu29CcVO> _menu29;

    /** セキュリティInfo */
    private List<SecurityInfoVO> _secinfo;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * 画面項目表示列制御マスタを取得する
     *
     * @return 画面項目表示列制御マスタ
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * 画面項目表示列制御マスタを設定する
     *
     * @param dc 画面項目表示列制御マスタ
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

    /**
     * コードマスタを取得する
     *
     * @return コードマスタ
     */
    public List<Mbj12CodeVO> getCode() {
        return _code;
    }

    /**
     * コードマスタを設定する
     *
     * @param code コードマスタ
     */
    public void setCode(List<Mbj12CodeVO> code) {
        _code = code;
    }

    /**
     * 部門マスタを取得する
     *
     * @return 部門マスタ
     */
    public List<Mbj06HcBumonVO> getBumon() {
        return _bumon;
    }

    /**
     * 部門マスタを設定する
     *
     * @param bumon 部門マスタ
     */
    public void setBumon(List<Mbj06HcBumonVO> bumon) {
        _bumon = bumon;
    }

    /**
     * カレンダーマスタを取得する
     *
     * @return カレンダーマスタ
     */
    public List<Mbj21CalendarVO> getCalendar() {
        return _calendar;
    }

    /**
     * カレンダーマスタを設定する
     *
     * @param calendar カレンダーマスタ
     */
    public void setCalendar(List<Mbj21CalendarVO> calendar) {
        _calendar = calendar;
    }

    /**
     * HCユーザマスタを取得する
     *
     * @return HCユーザマスタ
     */
    public List<Mbj07HcUserVO> getUser() {
        return _user;
    }

    /**
     * HCユーザマスタを取得する
     *
     * @param user HCユーザマスタ
     */
    public void setUser(List<Mbj07HcUserVO> user) {
        _user = user;
    }

    /**
     * 媒体費管理を取得します
     *
     * @return 媒体費管理
     */
    public List<Tbj03MediaMngVO> getMediaMng() {
        return _mediaMng;
    }

    /**
     * 媒体費管理を設定します
     *
     * @param mediaMng 媒体費管理
     */
    public void setMediaMng(List<Tbj03MediaMngVO> mediaMng) {
        _mediaMng = mediaMng;
    }

    /**
     * 媒体・商品紐付けマスタを取得します
     *
     * @return 媒体・商品紐付けマスタ
     */
    public List<FindMediaProductVO>  getMediaProduct() {
        return _mediaProduct;
    }

    /**
     * 媒体・商品紐付けマスタを設定します
     *
     * @param mediaProduct 媒体・商品紐付けマスタ
     */
    public void setMediaProduct(List<FindMediaProductVO> mediaProduct) {
        _mediaProduct = mediaProduct;
    }

    /**
     * 媒体費見積明細管理を取得します
     *
     * @return 媒体費見積明細管理
     */
    public List<Tbj04MediaMngEstimateDetailVO> getEstDtl() {
        return _estDtl;
    }

    /**
     * 媒体費見積明細管理を設定します
     *
     * @param estDtl 媒体費見積明細管理
     */
    public void setEstDtl(List<Tbj04MediaMngEstimateDetailVO> estDtl) {
        _estDtl = estDtl;
    }

    /**
     * H新モデルコスト合計を取得します
     *
     * @return H新モデルコスト合計
     */
    public List<FindSumHmCostVO> getSumHmCost() {
        return _sumHmCost;
    }

    /**
     * H新モデルコスト合計を設定します
     *
     * @param sumHmCost H新モデルコスト合計
     */
    public void setSumHmCost(List<FindSumHmCostVO> sumHmCost) {
        _sumHmCost = sumHmCost;
    }

    /**
     * 車種を取得します
     *
     * @return 車種
     */
    public List<CarListVO> getCar() {
        return _car;
    }

    /**
     * 車種を設定します
     *
     * @param car 車種
     */
    public void setCar(List<CarListVO> car) {
        _car = car;
    }

    /**
     * 媒体を取得します
     *
     * @return 媒体
     */
    public List<MediaListVO> getMedia() {
        return _media;
    }

    /**
     * 媒体を設定します
     *
     * @param media 媒体
     */
    public void setMedia(List<MediaListVO> media) {
        _media = media;
    }

    /**
     * 見積案件/見積明細を取得します
     *
     * @return 見積案件/見積明細
     */
    public List<FindEstItemDtlVO> getEstItemDtl() {
        return _estItemDtl;
    }

    /**
     * 見積案件/見積明細を設定します
     *
     * @param estItemDtl 見積案件/見積明細
     */
    public void setEstItemDtl(List<FindEstItemDtlVO> estItemDtl) {
        _estItemDtl = estItemDtl;
    }

    /**
     * HC商品マスタを取得する
     *
     * @return HC商品マスタ
     */
    public List<FindHCProductVO> getProduct() {
        return _product;
    }

    /**
     * HC商品マスタを設定する
     *
     * @param product HC商品マスタ
     */
    public void setProduct(List<FindHCProductVO> product) {
        _product = product;
    }

    /**
     * 全社コードマスタを取得する
     *
     * @return 全社コードマスタ
     */
    public List<RepaVbjaMeu29CcVO>  getMenu29() {
        return _menu29;
    }

    /**
     * 全社コードマスタを設定する
     *
     * @param menu29 全社コードマスタ
     */
    public void setMenu29(List<RepaVbjaMeu29CcVO> menu29) {
        _menu29 = menu29;
    }

    /**
     * セキュリティInfoVOリストを取得する
     * @return セキュリティInfoVOリスト
     */
    public List<SecurityInfoVO> getSecurityInfoVoList() {
        return _secinfo;
    }

    /**
     * セキュリティInfoVOリストを設定する
     * @param secinfo セキュリティInfoVOリスト
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> secinfo) {
        _secinfo = secinfo;
    }

    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
    }
}
