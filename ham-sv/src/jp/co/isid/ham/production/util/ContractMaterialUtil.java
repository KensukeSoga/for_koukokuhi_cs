package jp.co.isid.ham.production.util;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj38CarConvertVO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * 契約・素材に関するユーティリティクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/04 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractMaterialUtil {

    /**
     * HC部門コード(Fee案件請求用)取得
     * @return 検索結果
     * @throws HAMException
     */
    public static Mbj38CarConvertVO getCarConvertUpdateVo(Tbj20SozaiKanriListVO tbj20Vo) throws HAMException {

        Mbj38CarConvertVO mbj38Vo = new Mbj38CarConvertVO();

        //フェイズ基準値設定
        int carConvPhase;
        int month = Integer.parseInt(new SimpleDateFormat("yyyy").format(tbj20Vo.getSOZAIYM()));
        int year = Integer.parseInt(new SimpleDateFormat("yyyy").format(tbj20Vo.getSOZAIYM()));

        //フェイズ基準値取得
        Mbj12CodeDAO mbj12dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition mbj12cond = new Mbj12CodeCondition();
        mbj12cond.setCodetype(HAMConstants.CODETYPE_PHASE);
        mbj12cond.setKeycode(HAMConstants.CODETYPE_PHASE_0);
        List<Mbj12CodeVO> mbj12list = mbj12dao.selectVO(mbj12cond);

        if (month < HAMConstants.MONTH_APR) {
            //対象の月：1月～3月
            carConvPhase = year - Integer.parseInt(mbj12list.get(0).getYOBI1()) - 1;
        } else {
            //対象の月：4月～12月
            carConvPhase = year - Integer.parseInt(mbj12list.get(0).getYOBI1());
        }
        mbj38Vo.setPHASE(BigDecimal.valueOf(carConvPhase));

        //素材年月
        mbj38Vo.setSOZAIYM(tbj20Vo.getSOZAIYM());
        //データ更新日時
        mbj38Vo.setUPDDATE(tbj20Vo.getUPDDATE());
        //データ更新者
        mbj38Vo.setUPDNM(tbj20Vo.getUPDNM());
        //更新プログラム
        mbj38Vo.setUPDAPL(tbj20Vo.getUPDAPL());
        //更新担当者ID
        mbj38Vo.setUPDID(tbj20Vo.getUPDID());

        return mbj38Vo;
    }

}
