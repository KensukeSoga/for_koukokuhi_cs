package jp.co.isid.ham.menu.service;

import javax.jws.WebParam;
import javax.jws.WebService;

import jp.co.isid.ham.menu.controller.FindMainMenuCmd;
import jp.co.isid.ham.menu.model.FindMainMenuCondition;
import jp.co.isid.ham.menu.model.FindMainMenuResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
 *
 * <P>
 * メニューサービス
 * </P>
 * <P>
 * メニューサービスクラスです
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/10/04 JSE H.Abe)<BR>
 * </P>
 *
 * @author JSE H.Abe
 */
@WebService(serviceName = "menuService", targetNamespace = "http://service.menu.ham.isid.co.jp/")
public class MenuService {

    /**
     * メインメニューの表示データを取得する
     *
     * @param condition 条件
     * @return 検索結果
     * @throws ServiceException
     */
    public FindMainMenuResult findMainMenu(
            @WebParam(name = "condition") FindMainMenuCondition condition)
            throws ServiceException{

        try {
            FindMainMenuCmd cmd = new FindMainMenuCmd();
            cmd.setMainMenuCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMainMenuResult();
        } catch (HAMException e) {
            FindMainMenuResult result = new FindMainMenuResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
}